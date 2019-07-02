using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRenderer
{
    [Serializable]
    class KdTreeNode
    {
        public List<Entity> entities;
        public bool isLeaf;
        public int deep;
        public byte axis;
        public float position;
        public Box box;
        public KdTreeNode left;
        public KdTreeNode right;

        private byte relative(Entity item, byte axis2, float pos)
        {
            byte relativepos = 1;
            bool l = false, r = false, l1 = false, r1 = false;
            switch (axis2)
            {
                case 0:
                    r = item.shape.box.max.x < pos;
                    l1 = item.shape.box.min.x > pos;
                    break;
                case 1:
                    r = item.shape.box.max.y < pos;
                    l1 = item.shape.box.min.y > pos;
                    break;
                case 2:
                    r = item.shape.box.max.z < pos;
                    l1 = item.shape.box.min.z > pos;
                    break;
            }
            if (r) { relativepos = 0; }
            else if (l1) { relativepos = 2; }
            return relativepos;
        }
        private float cost(List<Entity> whole, byte axis2, float pos)
        {
            float o = 0;
            bool alll = true, allr = true;
            float left = 0, right = 0;
            switch (axis2)
            {
                case 0:
                    left = box.min.x;
                    right = box.max.x;
                    break;
                case 1:
                    left = box.min.y;
                    right = box.max.y;
                    break;
                case 2:
                    left = box.min.z;
                    right = box.max.z;
                    break;
            }
            foreach (Entity item in whole)
            {
                int relativepos = relative(item, axis2, pos);
                if (pos == 0)
                {
                    pos += 0;
                }
                if (relativepos == 0) allr = false;
                else if (relativepos == 2) alll = false;
                else alll = allr = false;
                if (relativepos == 1) o += 3;
                else if (relativepos == 0) o += (pos - left) / (right - left) * 3;
                else o += (right - pos) / (right - left) * 3;
            }
            // if (allr || alll) o = 2;
            // else 
            o += 2;
            //if (o < 0)
            //{
            //    o += 0;
            //}
            return o;
        }
        public KdTreeNode(List<Entity> whole, int d = 0, int maxdeep = 0, Box bigbox = null)
        {
            entities = null;
            deep = d;
            if (deep <= 3)
            {
                deep = deep;
            }
            if (maxdeep == 0) maxdeep = 8 + (int)Math.Log10(whole.Count);
            
                Box largestbox = new Box();
                largestbox.min.x = float.MaxValue;
                largestbox.min.y = float.MaxValue;
                largestbox.min.z = float.MaxValue;
                largestbox.max.x = float.MinValue;
                largestbox.max.y = float.MinValue;
                largestbox.max.z = float.MinValue;
                foreach (Entity item in whole)
                {
                    Box tmp = item.shape.box;
                    if (tmp.min.x < largestbox.min.x) largestbox.min.x = tmp.min.x;
                    if (tmp.max.x > largestbox.max.x) largestbox.max.x = tmp.max.x;
                    if (tmp.min.y < largestbox.min.y) largestbox.min.y = tmp.min.y;
                    if (tmp.max.y > largestbox.max.y) largestbox.max.y = tmp.max.y;
                    if (tmp.min.z < largestbox.min.z) largestbox.min.z = tmp.min.z;
                    if (tmp.max.z > largestbox.max.z) largestbox.max.z = tmp.max.z;
                }
                
            if (bigbox == null)
            {
                box = largestbox;
            }
            else
            {
                box = bigbox;
            }
            float cos = float.MaxValue;
            float pos = 0;
            byte ax = 0;
            foreach (Entity item in whole)
            {
                float lpos = 0f, rpos = 0f;
                for (byte axies = 0; axies < 3; ++axies)
                {
                    switch (axies)
                    {
                        case 0:
                            lpos = item.shape.box.min.x > box.min.x ? item.shape.box.min.x : box.min.x;
                            rpos = item.shape.box.max.x < box.max.x ? item.shape.box.max.x : box.max.x;
                            break;
                        case 1:
                            lpos = item.shape.box.min.y > box.min.y ? item.shape.box.min.y : box.min.y;
                            rpos = item.shape.box.max.y < box.max.y ? item.shape.box.max.y : box.max.y;
                            break;
                        case 2:
                            lpos = item.shape.box.min.z > box.min.z ? item.shape.box.min.z : box.min.z;
                            rpos = item.shape.box.max.z < box.max.z ? item.shape.box.max.z : box.max.z;
                            break;
                    }
                    //if (rpos < -11)
                    //{
                    //    lpos += 1;
                    //}
                    float lcos = cost(whole, axies, lpos);
                    float rcos = cost(whole, axies, rpos);
                    if (cos > lcos)
                    {
                        cos = lcos;
                        pos = lpos;
                        ax = axies;
                    }
                    if (cos > rcos)
                    {
                        cos = rcos;
                        pos = rpos;
                        ax = axies;
                    }

                }
            }
            int nosplitcos = 1 + 3 * whole.Count;
            if (2 * cos >= nosplitcos || deep >= maxdeep)
            {
                isLeaf = true;
                entities = whole;
                left = null;
                right = null;
            }
            else
            {
                axis = ax;
                position = pos;
                isLeaf = false;
                List<Entity> leftwhole = new List<Entity>();
                List<Entity> rightwhole = new List<Entity>();
                foreach (Entity item in whole)
                {
                    byte relativepos = relative(item, axis, position);
                    if (relativepos == 0) leftwhole.Add(item);
                    else if (relativepos == 2) rightwhole.Add(item);
                    else
                    {
                        leftwhole.Add(item);
                        rightwhole.Add(item);
                    }
                }
                deep++;
                Box lbox = new Box();
                Box rbox = new Box();
                lbox.min.x = rbox.min.x = box.min.x;
                lbox.max.x = rbox.max.x = box.max.x;
                lbox.min.y = rbox.min.y = box.min.y;
                lbox.max.y = rbox.max.y = box.max.y;
                lbox.min.z = rbox.min.z = box.min.z;
                lbox.max.z = rbox.max.z = box.max.z;
                switch (axis)
                {
                    case 0:
                        rbox.min.x = pos - 0.01f;
                        lbox.max.x = pos + 0.01f;
                        break;
                    case 1:
                        rbox.min.y = pos - 0.01f;
                        lbox.max.y = pos + 0.01f;
                        break;
                    case 2:
                        rbox.min.z = pos-0.01f;
                        lbox.max.z = pos+0.01f;
                        break;
                }
                left = new KdTreeNode(leftwhole, deep, maxdeep, lbox);
                right = new KdTreeNode(rightwhole, deep, maxdeep, rbox);
            }

        }
    }
}

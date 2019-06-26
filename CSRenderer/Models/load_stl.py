import struct
import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D


def load_vec(f):
    return [struct.unpack('<f', f.read(4))[0], 
            struct.unpack('<f', f.read(4))[0], 
            struct.unpack('<f', f.read(4))[0]]


def load_stl(filename):
    f = open(filename, 'rb')
    f.read(80)
    n = f.read(4)
    n = struct.unpack('<I', n)[0]
    result = []
    for _ in range(n):
        load_vec(f)
        for i in range(3):
            result.append(load_vec(f))
        f.read(2)
        
    print(f.read(20))
    print(f'total {n} triangles of model {filename} loading complete...')
    return np.array(result, dtype=np.float32)
    

if __name__ == "__main__":
    a = load_stl('Teapot.stl')
    print(a.shape)
    ax = plt.subplot(111, projection='3d')  # 创建一个三维的绘图工程
    ax.scatter(a[:, 0], a[:, 1], a[:, 2], c='y')  # 绘制数据点
    ax.set_xlabel('x')
    plt.show()
class Node:
    def __init__(self, info):
        self.info = info
        self.left = None
        self.right = None
        self.level = None

    def __str__(self):
        return str(self.info)


class BinarySearchTree:
    def __init__(self):
        self.root = None

    def create(self, val):
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root

            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break


# Enter your code here. Read input from STDIN. Print output to STDOUT
'''
class Node:
      def __init__(self,info): 
          self.info = info  
          self.left = None  
          self.right = None 


       // this is a node of the tree , which contains info as data, left , right
'''


def get_ancestors(root, x):
    trav = root
    ancestors = []
    while True:
        ancestors.append(trav)
        if str(trav) == x:
            return ancestors
        trav = trav.left if x < str(trav) else trav.right


def lca(root, v1, v2):
    v1_ancestors = get_ancestors(root, v1)
    v2_ancestors = get_ancestors(root, v2)
    i = 0
    lca = None
    while i < len(v1_ancestors) and i < len(v2_ancestors):
        if v1_ancestors[i] != v2_ancestors[i]:
            break
        lca = v1_ancestors[i]
        i += 1
    return lca

tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.create(arr[i])

v = list(map(int, input().split()))

ans = lca(tree.root, v[0], v[1])
print(ans.info)
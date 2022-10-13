namespace App20221004; 

public class Tree<T> {
    
    public TreeNode<T> Root { get; set; }

    public Tree(TreeNode<T> root) {
        Root = root;
    }

}
namespace App20221004; 

public class TreeNode<T> {
    
    public readonly List<TreeNode<T>> children = new();
    public TreeNode<T> parent { get; set; }
    public T data { get; set; }
    
    public bool isFocused;
    public bool isSelected;
    public int focusIndex;

    public TreeNode(T data) {
        this.data = data;
    }

    public TreeNode<T> Add(params TreeNode<T>[] data) {
        data.ToList().ForEach(x => {
            x.parent = this;
            children.Add(x);
        });
        return this;
    }





}
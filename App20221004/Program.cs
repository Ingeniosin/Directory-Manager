using App20221004;

public class Program {

    public static void Main() {
        var root = c("root");
        root.Add(
            c("Directory 1").Add(
                c("Directory 1.1"),
                c("Directory 1.2").Add(
                    c("Directory 1.2.1"),
                    c("Directory 1.2.2"),
                     c("Directory").Add(
                            c("Directory").Add(
                                c("Directory").Add(
                                    c("Directory").Add(
                                        c("Directory").Add(
                                            c("Directory")
                                        )
                                    )
                                )
                            )
                        )
                ),
                c("Directory 1.3").Add(
                    c("Directory 1.3.1").Add(
                        c("Directory").Add(
                            c("Directory").Add(
                                c("Directory").Add(
                                    c("Directory").Add(
                                        c("Directory").Add(
                                            c("Directory")
                                        )
                                    )
                                )
                            )
                        )
                    ),
                    c("Directory 1.3.2")
                ),
                c("Directory 1.4")
            ),
            c("Directory 2").Add(
                c("Directory 2.1").Add(
                    c("Directory 2.1.1"),
                    c("Directory 2.1.2"),
                    c("Directory 2.1.3"),
                    c("Directory 2.1.4")
                ),
                c("Directory 2.2").Add(
                    c("Directory 2.2.1"),
                    c("Directory 2.2.2"),
                    c("Directory 2.2.3"),
                    c("Directory 2.2.4")
                ),
                c("Directory 2.3").Add(
                    c("Directory 2.3.1"),
                    c("Directory 2.3.2"),
                    c("Directory 2.3.3"),
                    c("Directory 2.3.4")
                ),
                c("Directory 2.4").Add(
                    c("Directory 2.4.1"),
                    c("Directory 2.4.2"),
                    c("Directory 2.4.3"),
                    c("Directory 2.4.4")
                )
            ),
            c("Directory 3").Add(
                c("Directory 3.1").Add(
                    c("Directory 3.1.1"),
                    c("Directory 3.1.2"),
                    c("Directory 3.1.3"),
                    c("Directory 3.1.4")
                ),
                c("Directory 3.2"),
                c("Directory 3.3").Add(
                    c("Directory 3.3.1"),
                    c("Directory 3.3.2"),
                    c("Directory 3.3.3"),
                    c("Directory 3.3.4")
                ),
                c("Directory 3.4")
            ),
            c("Directory 4").Add(
                c("Directory 4.1").Add(
                    c("Directory 4.1.1"),
                    c("Directory 4.1.2"),
                    c("Directory 4.1.3").Add(
                        c("Directory 4.1.3.1")
                    ),
                    c("Directory 4.1.4").Add(
                        c("Directory 4.1.4.1"),
                        c("Directory 4.1.4.1")
                    )
                )
            )
        );

        var selectedHistory = new Stack<TreeNode<string>>();

        while(true) {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("        DIRECTORY MANAGER");
            Console.WriteLine("Ruta actual: /"+string.Join("/", selectedHistory.Select(x => x.data).Reverse()));
            Console.WriteLine(" ");
            PrintNode("", root);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Abrir  =  A;   Subir  =  S;  Salir =  Q");
            var key = Console.ReadKey();
            onKey(selectedHistory, root, key);
        }
    }

    private static void PrintNode(string prefix, TreeNode<string> node) {
        var items = node.children;
        for(var i = 0; i < items.Count; i++) {
            var item = items[i];
            if(item.isSelected) {
                var display = prefix + " * " + item.data + " -> ";
                var childPrefix = new string(' ', display.Length);
                Console.WriteLine(display);
                PrintNode(childPrefix, item);
            } else {
                var isFocused = node.focusIndex == i;
                if(isFocused) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(prefix + " * " + item.data);
                    Console.ForegroundColor = ConsoleColor.White;
                } else {
                    Console.WriteLine(prefix + " * " + item.data);
                }
            }
        }
    }
    
    private static void onKey(Stack<TreeNode<string>> selectedHistory, TreeNode<string> root, ConsoleKeyInfo key) {
        var currentNode = selectedHistory.Count == 0 ? root : selectedHistory.Peek();
        var items = currentNode.children;
        var maxIndex = items.Count-1;
        switch (key.Key) {
            case ConsoleKey.DownArrow:
                currentNode.focusIndex = currentNode.focusIndex == maxIndex ? 0 : currentNode.focusIndex+1;
                break;
            case ConsoleKey.UpArrow:
                currentNode.focusIndex = currentNode.focusIndex == 0 ? maxIndex : currentNode.focusIndex-1;
                break;
            case ConsoleKey.RightArrow when items.Count > 0: {
                var selected = items[currentNode.focusIndex];
                selected.isSelected = true;
                selectedHistory.Push(selected);
                break;
            }
            case ConsoleKey.LeftArrow when selectedHistory.Count > 0: {
                var selected = selectedHistory.Pop();
                selected.isSelected = false;
                break;
            }
        }
    }

    public static TreeNode<string> c(string item) => new(item);

}


; (function ($) {
    $.fn.zTree.contextmenu = function (options)
    {
        var treeObj,ctreeNode;
        var defaults = {
            menu: "",
            before:function(event, treeId, treeNode) {
                
            },
            after: function (event, treeId, treeNode) {

            },
            itemClick:
            {

            }
        };
        var opts = $.extend(defaults, options);

        var menu = $(defaults.menu);

        for (var item in defaults.itemClick)
        {
            if (defaults.itemClick[item] && typeof (defaults.itemClick[item]) == "function") {
                $("#" + defaults.itemClick[item]).bind("click", function (event) {
                    defaults.itemClick[item](event, treeObj, ctreeNode);
                });
            }
        }

        $.fn.zTree.OnRightClick = function (event, treeId, treeNode) {
            treeObj = $.fn.zTree.getZTreeObj(treeId);
            before(event, treeId, treeNode);
            if (!treeNode && event.target.tagName.toLowerCase() != "button" && $(event.target).parents("a").length == 0) {
                treeObj.cancelSelectedNode();
            } else if (treeNode && !treeNode.noR){
                ctreeNode = treeNode;
                treeObj.selectNode(treeNode);
                showMenu(event.clientX, event.clientY);
            }
            after(event, treeId, treeNode);
        };

        function showMenu(x, y) {
            menu.show();
            menu.css({ "top": y + "px", "left": x + "px", "visibility": "visible" });
            $("body").bind("mousedown", onBodyMouseDown);
        }

        //隐藏邮件执行
        function hideMenu() {
            if (menu) menu.css({ "visibility": "hidden" });
            $("body").unbind("mousedown", onBodyMouseDown);
        }

        function onBodyMouseDown(event) {
            if (!($(event.target) == menu || $(event.target).parents(_option.menu).length > 0)) {
                menu.css({ "visibility": "hidden" });
            }
        }
    }
})(jQuery)

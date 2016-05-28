var setting = {
    view: {
        showIcon: false
    },
    callback: {
        onClick: zTreeOnClick
    }
};
function zTreeOnClick(event, treeId, treeNode) {
    var treeObj = $.fn.zTree.getZTreeObj('tree');
    switch (treeNode.level) {
        case 0: $('#Grade').val(treeNode.name);
            $('#Grade_Son').val(null);
            $('#Grade_Grandson').val(null);
            break;
        case 1: $('#Grade_Son').val(treeNode.name);
            var node = treeObj.getNodeByTId(treeNode.parentTId);
            $('#Grade').val(node.name);
            $('#Grade_Grandson').val(null);
            break;
        case 2: $('#Grade_Grandson').val(treeNode.name);
            var node_son = treeObj.getNodeByTId(treeNode.parentTId);
            $('#Grade_Son').val(node_son.name);
            var node = treeObj.getNodeByTId(node_son.parentTId);
            $('#Grade').val(node.name);
            break;
        default:
            break;
    }
    Refresh();
}
///小学全部
var zNodes_primary_all = [
    {
        name: "一年级", open: true,
        children: [
            {
                name: "一年级上册"
            },
            {
                name: "一年级下册"
            }
        ]
    },
    {
        name: "二年级", open: true,
        children: [
            {
                name: "二年级上册"
            },
            {
                name: "二年级下册"
            }
        ]
    },
    {
        name: "三年级",
        children: [
            {
                name: "三年级上册"
            },
            {
                name: "三年级下册"
            }
        ]
    },
    {
        name: "四年级",
        children: [
            {
                name: "四年级上册"
            },
            {
                name: "四年级下册"
            }
        ]
    },
    {
        name: "五年级",
        children: [
            {
                name: "五年级上册"
            },
            {
                name: "五年级下册"
            }
        ]
    },
    {
        name: "六年级",
        children: [
            {
                name: "六年级上册"
            },
            {
                name: "六年级下册"
            }
        ]
    },


];

///初中语文
var zNodes_junior_yuwen = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]

    }]
},
{
    name: '八年级年级', open: true,
    children: [{
        name: '八年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]
    },
    {
        name: '八年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]
    }]
},
{
    name: '九年级', open: true,
    children: [{
        name: '九年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]
    },
    {
        name: '九年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        }]
    }]
}];

///初中数学
var zNodes_junior_shuxue = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        },
        {
            name: '第四章'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第五章'
        },
        {
            name: '第六章'
        },
        {
            name: '第七章'
        },
        {
            name: '第八章'
        },
        {
            name: '第九章'
        },
        {
            name: '第十章'
        }]
    }]
},
{
    name: '八年级',
    children: [{
        name: '八年级上册',
        children: [{
            name: '第十一章'
        },
        {
            name: '第十二章'
        },
        {
            name: '第十三章'
        },
        {
            name: '第十四章'
        },
        {
            name: '第十五章'
        }]
    },
    {
        name: '八年级下册',
        children: [{
            name: '第十六章'
        },
        {
            name: '第十七章'
        },
        {
            name: '第十八章'
        },
        {
            name: '第十九章'
        },
        {
            name: '第二十章'
        }]
    }]
},
{
    name: '九年级',
    children: [{
        name: '九年级上册',
        children: [{
            name: '第二十一章'
        },
        {
            name: '第二十二章'
        },
        {
            name: '第二十三章'
        },
        {
            name: '第二十四章'
        },
        {
            name: '第二十五章'
        }]
    },
    {
        name: '九年级下册',
        chileren: [{
            name: '第二十六章'
        },
        {
            name: '第二十七章'
        },
        {
            name: '第二十八章'
        },
        {
            name: '第二十九章'
        }
        ]
    }]
}];
///初中英语
var zNodes_junior_yingyu = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        },
        {
            name: '第九单元'
        },
        {
            name: '第十单元'
        },
        {
            name: '第十一单元'
        },
        {
            name: '第十二单元'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第一单元'
        },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       },
       {
           name: '第六单元'
       },
       {
           name: '第七单元'
       },
       {
           name: '第八单元'
       },
       {
           name: '第九单元'
       },
       {
           name: '第十单元'
       },
       {
           name: '第十一单元'
       },
       {
           name: '第十二单元'
       }]
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册',
            children: [{
                name: '第一单元'
            },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       },
       {
           name: '第六单元'
       },
       {
           name: '第七单元'
       },
       {
           name: '第八单元'
       },
       {
           name: '第九单元'
       },
       {
           name: '第十单元'
       },
       {
           name: '第十一单元'
       },
       {
           name: '第十二单元'
       }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第一单元'
            },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       },
       {
           name: '第六单元'
       },
       {
           name: '第七单元'
       },
       {
           name: '第八单元'
       },
       {
           name: '第九单元'
       },
       {
           name: '第十单元'
       }
            ]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            },
            {
                name: '第八单元'
            }]
        },
        {
            name: '九年级下册',
            children: [{
                name: '第九单元'
            },
            {
                name: '第十单元'
            },
            {
                name: '第十一单元'
            },
            {
                name: '第十二单元'
            },
            {
                name: '第十三单元'
            },
            {
                name: '第十四单元'
            },
            {
                name: '第十五单元'
            }]
        }]
    }];
///初中物理
var zNodes_junior_wuli = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true
    },
    {
        name: '七年级下册'
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册', open: true,
            children: [{
                name: '第一章'
            },
            {
                name: '第二章'
            },
            {
                name: '第三章'
            },
            {
                name: '第四章'
            },
            {
                name: '第四章'
            },
            {
                name: '第五章'
            },
            {
                name: '第六章'
            }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第七章'
            },
            {
                name: '第八章'
            },
            {
                name: '第九章'
            },
            {
                name: '第十章'
            },
            {
                name: '第十一章'
            },
            {
                name: '第十二章'
            }]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册',
            children: [{
                name: '第十三章'
            },
            {
                name: '第十四章'
            },
            {
                name: '第十五章'
            },
            {
                name: '第十六章'
            },
            {
                name: '第十七章'
            },
            {
                name: '第十八章'
            },
            {
                name: '第十九章'
            },
            {
                name: '第二十章'
            },
            {
                name: '第二十一章'
            },
            {
                name: '第二十二章'
            }]
        },
        {
            name: '九年级下册'
        }]
    }];
///初中化学
var zNodes_junior_huaxue = [{
    name: '七年级',
    children: [{
        name: '七年级上册', open: true
    },
    {
        name: '七年级下册'
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册'
        },
        {
            name: '八年级下册'
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册', open: true,
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            }]
        },
        {
            name: '九年级下册', open: true,
            children: [{
                name: '第八单元'
            },
            {
                name: '第九单元'
            },
            {
                name: '第十单元'
            },
            {
                name: '第十一单元'
            },
            {
                name: '第十二单元'
            }]
        }]
    }];
///初中历史
var zNodes_junior_lishi = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        }]
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            }]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            },
            {
                name: '第八单元'
            }]
        },
        {
            name: '九年级下册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            },
            {
                name: '第五单元'
            },
            {
                name: '第六单元'
            },
            {
                name: '第七单元'
            },
            {
                name: '第八单元'
            }]
        }]
    }];
///初中政治思品
var zNodes_junior_zhengzhisipin = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]

    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册',
            children: [{
                name: '第一单元'
            },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第一单元'
            },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册',
            children: [{
                name: '第一单元'
            },
            {
                name: '第二单元'
            },
            {
                name: '第三单元'
            },
            {
                name: '第四单元'
            }]
        },
        {
            name: '九年级下册'
        }]
    }];
///初中地理
var zNodes_junior_dili = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        },
        {
            name: '第四章'
        },
        {
            name: '第五章'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第六章'
        },
        {
            name: '第七章'
        },
        {
            name: '第八章'
        },
        {
            name: '第九章'
        },
        {
            name: '第十章'
        }]
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册',
            children: [{
                name: '第一章'
            },
            {
                name: '第二章'
            },
            {
                name: '第三章'
            },
            {
                name: '第四章'
            }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第五章'
            },
            {
                name: '第六章'
            },
            {
                name: '第七章'
            },
            {
                name: '第八章'
            },
            {
                name: '第九章'
            }]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册'
        },
        {
            name: '九年级下册'
        }]
    }];
///初中生物
var zNodes_junior_shengwu = [{
    name: '七年级', open: true,
    children: [{
        name: '七年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        }]
    },
    {
        name: '七年级下册',
        children: [{
            name: '第四单元'
        }]
    }]
},
    {
        name: '八年级',
        children: [{
            name: '八年级上册',
            children: [{
                name: '第五单元'
            },
            {
                name: '第六单元'
            }]
        },
        {
            name: '八年级下册',
            children: [{
                name: '第七单元'
            },
            {
                name: '第八单元'
            }]
        }]
    },
    {
        name: '九年级',
        children: [{
            name: '九年级上册'
        },
        {
            name: '九年级下册'
        }]
    }];
///高中语文
var zNodes_high_yuwen = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    }]
},
{
    name: '十一年级年级', open: true,
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    }]
},
{
    name: '十二年级', open: true,
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '十二年级下册'
    }]
}];
///高中数学
var zNodes_high_shuxue = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        },
        {
            name: '第四章'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        }]
    },
    {
        name: '十二年级下册'
    }]
}];
///高中英语
var zNodes_high_yingyu = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一单元'
        },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一单元'
        },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一单元'
        },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一单元'
        },
       {
           name: '第二单元'
       },
       {
           name: '第三单元'
       },
       {
           name: '第四单元'
       },
       {
           name: '第五单元'
       }]
    },
    {
        name: '十二年级下册'
    }]
}];
///高中物理
var zNodes_high_wuli = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        },
        {
            name: '第四章'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第五章'
        },
        {
            name: '第六章'
        },
        {
            name: '第七章'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
        {
            name: '第五章'
        }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
        {
            name: '第五章'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
        {
            name: '第五章'
        }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
        {
            name: '第五章'
        }]
    }]
}];
///高中化学
var zNodes_high_huaxue = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       }]
    }]
}];
///高中历史
var zNodes_high_lishi = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        },
        {
            name: '第九单元'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        },
        {
            name: '第六单元'
        },
        {
            name: '第七单元'
        },
        {
            name: '第八单元'
        }]
    }]
}];
///高中政治思品
var zNodes_high_zhengzhisipin = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一单元'
        },
        {
            name: '第二单元'
        },
        {
            name: '第三单元'
        },
        {
            name: '第四单元'
        },
        {
            name: '第五单元'
        }]
    }]
}];
///高中地理
var zNodes_high_dili = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一章'
        },
        {
            name: '第二章'
        },
        {
            name: '第三章'
        },
        {
            name: '第四章'
        },
        {
            name: '第五章'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    }]
}];
///高中生物
var zNodes_high_shengwu = [{
    name: '十年级', open: true,
    children: [{
        name: '十年级上册', open: true,
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    },
    {
        name: '十年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        },
        {
            name: '第七章'
        }]
    }]
},
{
    name: '十一年级',
    children: [{
        name: '十一年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       }]
    },
    {
        name: '十一年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       },
        {
            name: '第六章'
        }]
    }]
},
{
    name: '十二年级',
    children: [{
        name: '十二年级上册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       }]
    },
    {
        name: '十二年级下册',
        children: [{
            name: '第一章'
        },
       {
           name: '第二章'
       },
       {
           name: '第三章'
       },
       {
           name: '第四章'
       },
       {
           name: '第五章'
       }]
    }]
}];

$(document).ready(function () {
    if ($('#Period').val() == '小学试题') {
        $.fn.zTree.init($('#tree'), setting, zNodes_primary_all);
    }
    else if ($('#Period').val() == '初中试题') {
        switch ($('#Subject').val()) {
            case '语文': $.fn.zTree.init($('#tree'), setting, zNodes_junior_yuwen); break;
            case '数学': $.fn.zTree.init($('#tree'), setting, zNodes_junior_shuxue); break;
            case '英语': $.fn.zTree.init($('#tree'), setting, zNodes_junior_yingyu); break;
            case '物理': $.fn.zTree.init($('#tree'), setting, zNodes_junior_wuli); break;
            case '化学': $.fn.zTree.init($('#tree'), setting, zNodes_junior_huaxue); break;
            case '历史': $.fn.zTree.init($('#tree'), setting, zNodes_junior_lishi); break;
            case '政治思品': $.fn.zTree.init($('#tree'), setting, zNodes_junior_zhengzhisipin); break;
            case '地理': $.fn.zTree.init($('#tree'), setting, zNodes_junior_dili); break;
            case '生物': $.fn.zTree.init($('#tree'), setting, zNodes_junior_shengwu); break;
            default: break;
        }
    }
    else {
        switch ($('#Subject').val()) {
            case '语文': $.fn.zTree.init($('#tree'), setting, zNodes_high_yuwen); break;
            case '数学': $.fn.zTree.init($('#tree'), setting, zNodes_high_shuxue); break;
            case '英语': $.fn.zTree.init($('#tree'), setting, zNodes_high_yingyu); break;
            case '物理': $.fn.zTree.init($('#tree'), setting, zNodes_high_wuli); break;
            case '化学': $.fn.zTree.init($('#tree'), setting, zNodes_high_huaxue); break;
            case '历史': $.fn.zTree.init($('#tree'), setting, zNodes_high_lishi); break;
            case '政治思品': $.fn.zTree.init($('#tree'), setting, zNodes_high_zhengzhisipin); break;
            case '地理': $.fn.zTree.init($('#tree'), setting, zNodes_high_dili); break;
            case '生物': $.fn.zTree.init($('#tree'), setting, zNodes_high_shengwu); break;
            default: break;
        }
    }
});
$(function () {
    for (var i = 1; i <= 5; i++) {
        new webkit_draggable('img3a' + i, {
            revert: 'invalid'
        });
    }

    webkit_drop.add("img3b1", {
        apect: ["img3a1", "img3a3", "img3a2", "img3a5", "img3a4"],
        onDrop: function (event, ui) {
            var draggableId = event.id;
            console.log(draggableId); //lấy dữ liệu ra để debug
            //alert(droppableId);
            var valueDropImg = document.getElementById('img3b1');
            var valueDragImg = document.getElementById(draggableId);
            switch (draggableId) {
                case "img3a1":
                    {
                        webkit_drop.remove('img3b1');
                        getImgscr(valueDragImg, valueDropImg, 1, "img3b1");
                    }
                    break;
                case "img3a2":
                    {
                        webkit_drop.remove('img3b1');
                        getImgscr(valueDragImg, valueDropImg, 2,"img3b1");
                    }
                    break;
                case "img3a3":
                    {
                        webkit_drop.remove('img3b1');
                        getImgscr(valueDragImg, valueDropImg, 3, "img3b1");
                    }
                    break;
                case "img3a4":
                    {
                        webkit_drop.remove('img3b1');
                        getImgscr(valueDragImg, valueDropImg, 4, "img3b1");
                    }
                    break;
                case "img3a5":
                    {
                        webkit_drop.remove('img3b1');
                        getImgscr(valueDragImg, valueDropImg, 5, "img3b1");
                    }
                    break;
            }

        }
    });
    webkit_drop.add("img3b2", {
        apect: ["img3a1", "img3a3", "img3a2", "img3a5", "img3a4"],
        onDrop: function (event, ui) {
            var draggableId = event.id;
            console.log(draggableId); //lấy dữ liệu ra để debug
            //alert(droppableId);
            var valueDropImg = document.getElementById('img3b2');
            var valueDragImg = document.getElementById(draggableId);
            switch (draggableId) {
                case "img3a1":
                    {
                        webkit_drop.remove('img3b2');
                        getImgscr(valueDragImg, valueDropImg, 1, "img3b2");
                    }
                    break;
                case "img3a2":
                    {
                        webkit_drop.remove('img3b2');
                        getImgscr(valueDragImg, valueDropImg, 2, "img3b2");
                    }
                    break;
                case "img3a3":
                    {
                        webkit_drop.remove('img3b2');
                        getImgscr(valueDragImg, valueDropImg, 3, "img3b2");
                    }
                    break;
                case "img3a4":
                    {
                        webkit_drop.remove('img3b2');
                        getImgscr(valueDragImg, valueDropImg, 4, "img3b2");
                    }
                    break;
                case "img3a5":
                    {
                        webkit_drop.remove('img3b2');
                        getImgscr(valueDragImg, valueDropImg, 5, "img3b2");
                    }
                    break;
            }


        }
    });
    webkit_drop.add("img3b3", {
        apect: ["img3a1", "img3a3", "img3a2", "img3a5", "img3a4"],
        onDrop: function (event, ui) {
            var draggableId = event.id;
            console.log(draggableId); //lấy dữ liệu ra để debug
            //alert(droppableId);
            var valueDropImg = document.getElementById('img3b3');
            var valueDragImg = document.getElementById(draggableId);
            switch (draggableId) {
                case "img3a1":
                    {
                        webkit_drop.remove('img3b3');
                        getImgscr(valueDragImg, valueDropImg, 1, "img3b3");
                    }
                    break;
                case "img3a2":
                    {
                        webkit_drop.remove('img3b3');
                        getImgscr(valueDragImg, valueDropImg, 2, "img3b3");
                    }
                    break;
                case "img3a3":
                    {
                        webkit_drop.remove('img3b3');
                        getImgscr(valueDragImg, valueDropImg, 3, "img3b3");
                    }
                    break;
                case "img3a4":
                    {
                        webkit_drop.remove('img3b3');
                        getImgscr(valueDragImg, valueDropImg, 4, "img3b3");
                    }
                    break;
                case "img3a5":
                    {
                        webkit_drop.remove('img3b3');
                        getImgscr(valueDragImg, valueDropImg, 5, "img3b3");
                    }
                    break;
            }


        }
    });
    webkit_drop.add("img3b4", {
        apect: ["img3a1", "img3a3", "img3a2", "img3a5", "img3a4"],
        onDrop: function (event, ui) {
            var draggableId = event.id; // lấy id của th được kéo.
            console.log(draggableId); //lấy dữ liệu ra để debug
            //alert(droppableId);
            var valueDropImg = document.getElementById('img3b4');
            var valueDragImg = document.getElementById(draggableId);
            switch (draggableId) {
                case "img3a1":
                    {
                        webkit_drop.remove('img3b4');
                        getImgscr(valueDragImg, valueDropImg, 1, "img3b4");
                    }
                    break;
                case "img3a2":
                    {
                        webkit_drop.remove('img3b4');
                        getImgscr(valueDragImg, valueDropImg, 2, "img3b4");
                    }
                    break;
                case "img3a3":
                    {
                        webkit_drop.remove('img3b4');
                        getImgscr(valueDragImg, valueDropImg, 3, "img3b4");
                    }
                    break;
                case "img3a4":
                    {
                        webkit_drop.remove('img3b4');
                        getImgscr(valueDragImg, valueDropImg, 4, "img3b4");
                    }
                    break;
                case "img3a5":
                    {
                        webkit_drop.remove('img3b4');
                        getImgscr(valueDragImg, valueDropImg, 5, "img3b4");
                    }
                    break;
            }
        }
    });
    webkit_drop.add("img3b5", {
        apect: ["img3a1", "img3a3", "img3a2", "img3a5", "img3a4"],
        onDrop: function (event, ui) {
            var draggableId = event.id; // lấy id của th được kéo.
            console.log(draggableId); //lấy dữ liệu ra để debug
            //alert(droppableId);
            var valueDropImg = document.getElementById('img3b5');
            var valueDragImg = document.getElementById(draggableId);
            switch (draggableId) {
                case "img3a1":
                    {
                        webkit_drop.remove('img3b5');
                        getImgscr(valueDragImg, valueDropImg, 1, "img3b5");
                    }
                    break;
                case "img3a2":
                    {
                        webkit_drop.remove('img3b5');
                        getImgscr(valueDragImg, valueDropImg, 2, "img3b5");
                    }
                    break;
                case "img3a3":
                    {
                        webkit_drop.remove('img3b5');
                        getImgscr(valueDragImg, valueDropImg, 3, "img3b5");
                    }
                    break;
                case "img3a4":
                    {
                        webkit_drop.remove('img3b5');
                        getImgscr(valueDragImg, valueDropImg, 4, "img3b5");
                    }
                    break;
                case "img3a5":
                    {
                        webkit_drop.remove('img3b5');
                        getImgscr(valueDragImg, valueDropImg, 5, "img3b5");
                    }
                    break;
            }
        }
    });
})



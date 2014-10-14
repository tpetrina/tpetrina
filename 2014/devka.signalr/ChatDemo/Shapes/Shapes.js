/// <reference path="d:\dev\GitHub\presentations\2014\devka.signalr\ChatDemo\Scripts/jquery-1.6.4.js" />
/// <reference path="d:\dev\GitHub\presentations\2014\devka.signalr\ChatDemo\Scripts/jquery-ui-1.11.1.js" />
/// <reference path="d:\dev\GitHub\presentations\2014\devka.signalr\ChatDemo\Scripts/jquery.signalR-2.1.2.js" />

$(function () {

    var hub = $.connection.Shapes;
    var $shape = $("#shape");


    hub.client.shapeMoved = function (x, y) {
        $shape.css({ left: x, top: y });
    };


    $.connection.hub.start().done(function () {
        $shape.draggable({
            drag: function () {
                hub.server.moveShape(this.offsetLeft, this.offsetTop || 0);
            }
        });
    });

});
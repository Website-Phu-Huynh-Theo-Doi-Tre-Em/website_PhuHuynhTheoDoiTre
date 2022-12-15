//tự động load lại trang
function refresh() { location.reload(); }
// Tính độ dài
$(function () {
    $('body').css('cursor', 'grab');
    var cw_frame = $('.form-game').width();
    $('.form-game').css({ 'height': (cw_frame * 0.475) + 'px' });
})
$(document).on({
    'mousemove': function (e) {
        $('body').css('cursor', 'grab');
    },
    'mousedown': function (e) {
        $('body').css('cursor', 'grabbing');
    },
    'mouseup': function () {
        $('body').css('cursor', 'grab');
    }
});
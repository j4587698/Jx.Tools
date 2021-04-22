(function ($) {
    $.extend({
        crop: function(el, method, param1, param2) {
            var $el = $(el);
            $el.cropper({viewMode:2});
        }
    });
})(jQuery);
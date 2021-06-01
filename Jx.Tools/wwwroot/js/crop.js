(function ($) {
    $.extend({
        crop: function(el, obj, args) {
            var $el = $(el);
            $el.croppie('destroy');
            $el.croppie(args);
        }
    });
})(jQuery);
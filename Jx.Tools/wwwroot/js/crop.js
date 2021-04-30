(function ($) {
    $.extend({
        crop: function(el) {
            var $el = $(el);
            $el.croppie({viewport:{
                width: 400, 
                height:400
                }
            });
        },
        doCrop: function (el, method){
            var $el = $(el);
            $el.croppie(method);
        }
    });
})(jQuery);
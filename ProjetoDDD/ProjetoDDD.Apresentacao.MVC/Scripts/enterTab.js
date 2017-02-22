function tabimput(){ 
    $("input").not($(":button")).keypress(function (evt) {
        if (evt.keyCode == 13) {
            iname = $(this).val();
            if (iname !== 'Submit') {
                var fields = $(this).parents('form:eq(0),body').find('button, input, textarea, select');
                var index = fields.index(this);
                if (index > -1 && (index + 1) < fields.length) {
                    fields.eq(index + 1).focus();
                }
                return false;
            }
        }
    });
};


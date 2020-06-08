$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        var name = camelize(this.name);

        if (o[name]) {
            if (!o[name].push) {
                o[name] = [o[name]];
            }
            o[name].push(this.value || '');
        } else {
            o[name] = this.value || '';
        }
    });
    return o;
};
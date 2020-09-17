/**
 * date:2020/02/27
 * author:
 * version:2.0
 * description:layuimini miniLayer扩展
 */
layui.define(["element", "jquery"], function (exports) {
    var element = layui.element,
        $ = layui.$,
        _WIN = $(window);


    var miniLayer = {

        msg: function (content) {
            this.alert({ content: content});
        },
        alert: function (options) {
            var ops = {
                title: '提示',
                time: 0,
                anim: 5,
                content:""
            }
            $.extend(ops, options);
            if (parent.layer) {
                parent.layer.alert(ops.content, {
                    title: ops.title,
                    skin: 'layui-layer-lan',
                    closeBtn: 0,
                    time: ops.time,
                    anim: ops.anim 
                });
            }
            else {
                layer.alert(ops.content, {
                    title: ops.title,
                    skin: 'layui-layer-lan',
                    closeBtn: 0,
                    time: ops.time,
                    anim: ops.anim 
                });
            }
        },
        dialog: function (options) {
            //Loading(true);
            var defaults = {
                //id: null,
                title: '系统窗口',
                width: null,
                height: null,
                url: '',
                shade: 0.4,
                btn: [],
                callBack: null,
                end: null,
                full: false,
            };
            var thatLayIndex;
            var options = $.extend(defaults, options);
            var thatlayer = parent.layer || layer;
            var _url = options.url;
            var _width, _height;
            if (options.width == null || options.width == '') {
                _width = ($(window).width() * 0.9)+'px';
            }
            else {
                _width = $(window).width() > parseInt(options.width.replace('px', '')) ? options.width : $(window).width() + 'px';
            }
            if (options.height == null || options.height == '') {
                _height = ($(window).height() - 50) + 'px';
            } else {
                _height = $(window).height() > parseInt(options.height.replace('px', '')) ? options.height : $(window).height() + 'px';
            }
            if (options.btn.length > 1) {
                thatLayIndex = thatlayer.open({
                    id: options.id,
                    type: 2,
                    shade: options.shade,
                    title: options.title,
                    fixed: false, //不固定
                    maxmin: true,
                    area: [_width, _height],
                    content: _url,
                    btn: options.btn,
                    yes: function (i, obj) {
                        options.callBack($(obj.find("iframe")).attr("id"),i,obj)
                    }, cancel: function () {
                        return true;
                    },
                    end: function () {
                        options.end && options.end();
                    }
                });
            }
            else {
                thatLayIndex = thatlayer.open({
                    id: options.id,
                    type: 2,
                    shade: options.shade,
                    title: options.title,
                    fixed: false, //不固定
                    maxmin: true,
                    area: [_width, _height],
                    content: _url,
                    btn: options.btn,
                    cancel: function () {
                        return true;
                    },
                    end: function () {
                        options.end && options.end();
                    }
                });
            }
            if (options.full) {
                thatlayer.full(thatLayIndex);
            }
            return thatLayIndex;
        },
        /**
       * [confirm 弹出询问框]
       * @param  {[type]}  content [提示框内容]
       * @param  {[type]}  title   [提示框标题]
       * @param  {[type]}  callbackmething [执行函数]
       */
        confirm : function (content, title, callbackmething) {
            var _title = '提示';
            var _callback = callbackmething;
            if (typeof title === "function") {
                _callback = title;
            } else {
                _title = title;
            }

            layer.confirm(content, {
                title: _title,
                skin: 'layui-layer-lan',
                closeBtn: 0,
                anim: 5
            },
                function (index) {
                    if (typeof _callback === "function") {
                        _callback();
                    }
                    layer.close(index);
                });
        },
        /**
         * [msghide 弹出半透明提示层]
         * @param  {[type]}  content [提示框内容]
         * @param  {[type]}  time    [自动关闭]
         */
        msghide : function (content, time) {
            var _time = 2000;
            if (typeof time === 'number') {
                _time = time;
            }
            if (parent.layer) {
                parent.layer.msg(content, {
                    time: _time
                });
            }
            else {
                layer.msg(content, {
                    time: _time
                });
            }
        },
        parReload: function (content) {
            var p = $('.layui-show', window.parent.document).children()[0].contentWindow;
            p.reload();
        },
        parCurrent: function () {
            return $('.layui-show', window.parent.document).children()[0].contentWindow;
        }
    };

    exports("miniLayer", miniLayer);
});
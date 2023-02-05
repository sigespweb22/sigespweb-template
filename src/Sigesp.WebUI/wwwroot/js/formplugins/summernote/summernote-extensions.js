//button tools personalizado - Aa | Muda o texto selecionado para letra maiúscula ou minúscula
var upperCase = function (context) {
  var ui = $.summernote.ui;

  var button = ui.buttonGroup([
      ui.button({
        className: "dropdown-toggle",
        contents:
            '<i class="fal fa-font-case"/>',
        data: {
            toggle: "dropdown",
        },
      }),
      ui.dropdown({
      className: "drop-default summernote-list",
      contents:
          '<div class="btn-group">' +
          '<button type="button" class="btn btn-upper btn-default btn-sm" title="MAIÚSCULA"><i class="fa fa-file-pdf-o"></i>MAIÚSCULA</button>' +
          '<button type="button" class="btn btn-lower btn-default btn-sm" title="minúscula"><i class="fa fa-file-pdf-o"></i>minúscula</button></div>',
      callback: function ($dropdown) {
              $dropdown.find(".btn-upper").click(function () {
                var editor = context.$note;

                var r = editor.summernote('createRange');
                r.pasteHTML(r.toString().toUpperCase());
                
              });

              $dropdown.find(".btn-lower").click(function () {
                var editor = context.$note;

                var r = editor.summernote('createRange');
                r.pasteHTML(r.toString().toLowerCase());
              });
          },
      }),
  ]);

  return button.render(); // return button as jquery object
};
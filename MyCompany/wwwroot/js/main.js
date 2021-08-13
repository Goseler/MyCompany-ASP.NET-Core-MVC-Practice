/*
	Minimaxing by HTML5 UP
	html5up.net | @ajlkn
	Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)
*/

(function ($) {

	var $window = $(window),
		$body = $('body');

	// Breakpoints.
	breakpoints({
		xlarge: ['1281px', '1680px'],
		large: ['981px', '1280px'],
		medium: ['737px', '980px'],
		small: [null, '736px']
	});

	// Nav.

	// Title Bar.
	$(
		'<div id="titleBar">' +
		'<a href="#navPanel" class="toggle"></a>' +
		'<span class="title">' + $('#logo').html() + '</span>' +
		'</div>'
	)
		.appendTo($body);

	// Navigation Panel.
	$(
		'<div id="navPanel">' +
		'<nav>' +
		$('#nav').navList() +
		'</nav>' +
		'</div>'
	)
		.appendTo($body)
		.panel({
			delay: 500,
			hideOnClick: true,
			hideOnSwipe: true,
			resetScroll: true,
			resetForms: true,
			side: 'left',
			target: $body,
			visibleClass: 'navPanel-visible'
		});

})(jQuery);

const watchdog = new CKSource.EditorWatchdog();

window.watchdog = watchdog;

watchdog.setCreator((element, config) => {
    return CKSource.Editor
        .create(element, config)
        .then(editor => {




            return editor;
        })
});

watchdog.setDestructor(editor => {



    return editor.destroy();
});

watchdog.on('error', handleError);

watchdog
    .create(document.querySelector('#editor'), {

        toolbar: {
            items: [
                'heading',
                '|',
                'fontSize',
                'bold',
                'italic',
                'underline',
                'link',
                'fontFamily',
                'fontBackgroundColor',
                'fontColor',
                '|',
                'findAndReplace',
                'outdent',
                'indent',
                'alignment',
                'bulletedList',
                'numberedList',
                '|',
                /*'highlight',*/
                'horizontalLine',
                /*'blockQuote',*/
                'insertTable',
                /*'mediaEmbed',*/
                'specialCharacters',
                'undo',
                'redo'
            ]
        },
        language: 'ru',
        table: {
            contentToolbar: [
                'tableColumn',
                'tableRow',
                'mergeTableCells',
                'tableCellProperties',
                'tableProperties'
            ]
        },
        licenseKey: '',



    })
    .catch(handleError);

function handleError(error) {
    console.error('Oops, something went wrong!');
    console.error('Please, report the following error on https://github.com/ckeditor/ckeditor5/issues with the build id and the error stack trace:');
    console.warn('Build id: wvlz1qvwy9e3-mtx0289es78g');
    console.error(error);
}

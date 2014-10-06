
function svg_edit_setup() {
	var svgCanvas = new SvgCanvas(document.getElementById("svgcanvas"));
	var pos = $('#tools_rect_show').position();
	$('#tools_rect').css({'left': pos.left+2, 'top': pos.top+2});
	// This is a common function used when a tool has been clicked (chosen)
	// It does several common things:
	// - hides any flyout menus
	// - removes the tool_button_current class from whatever tool currently has it
	// - adds the tool_button_current class to the button passed in
	var toolButtonClick = function(button) {
		if ($(button).hasClass('tool_button_disabled')) return false;
		
		$('#styleoverrides').text('');
		$('.tools_flyout').hide();
		$('.tool_button_current').removeClass('tool_button_current').addClass('tool_button');
		$(button).addClass('tool_button_current');
		// when a tool is selected, we should deselect the currently selected element
		svgCanvas.selectNone();
		return true;
	};

	this.clickSelect = function() {
		if (toolButtonClick('#tool_select')) {
			svgCanvas.setMode('select');
			$('#styleoverrides').text('*{cursor:move;pointer-events:all} svg{cursor:default}');
		}
	}

        this.clickRect = function(){
		if (toolButtonClick('#tools_rect_show')) {
		    svgCanvas.setMode('rect');
		    
		}
	}

	//$('#tool_select').click(clickSelect);

	//$('#tool_rect').click(clickRect);
// this hides any flyouts and then shows the rect flyout
	$('#tools_rect_show').click(function(){
		$('.tools_flyout').hide();
		$('#tools_rect').show();
	});

	//return svgCanvas;
};

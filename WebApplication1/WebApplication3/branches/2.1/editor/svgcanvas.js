var svgcanvas = null;

function SvgCanvas(c)
{

// private members
	var canvas = this;
	var container = c;
	var svgns = "http://www.w3.org/2000/svg";

	var idprefix = "svg_";
	var svgdoc  = c.ownerDocument;
	var svgroot = svgdoc.createElementNS(svgns,"svg");
	svgroot.setAttribute("width", 640);
	svgroot.setAttribute("height", 480);
	svgroot.setAttribute("id", "svgroot");
	svgroot.setAttribute("xmlns", svgns);
	container.appendChild(svgroot);

	var d_attr = null;
	var started = false;
	var obj_num = 1;
	var start_x = null;
	var start_y = null;
	
	var current_fill = "none";
	var current_stroke = "black";
	var current_stroke_width = 1;
	var current_stroke_style = "none";
	var current_opacity = 1;
	var current_stroke_opacity = 1;
	var current_fill_opacity = 1;
	var current_font_size = "12pt";
	var current_font_family = "serif";
	
	var selected = null;
	//var selectedOutline = null;
	var events = {};

// private functions
	var getId = function() {
	    if (events["getid"])
	        return call("getid", obj_num);
		return idprefix+obj_num;
	}

	var call = function(event, arg) {
		if (events[event]) {
			return events[event](this,arg);
		}
	}

	var assignAttributes = function(node, attrs) {
		for (i in attrs) {
			node.setAttributeNS(null, i, attrs[i]);
		}
	}

	// remove unneeded attributes
	// makes resulting SVG smaller
	var cleanupElement = function(element) {
		if (element.getAttribute('fill-opacity') == '1')
			element.removeAttribute('fill-opacity');
		if (element.getAttribute('opacity') == '1')
			element.removeAttribute('opacity');
		if (element.getAttribute('stroke') == 'none')
			element.removeAttribute('stroke');
		if (element.getAttribute('stroke-dasharray') == 'none')
			element.removeAttribute('stroke-dasharray');
		if (element.getAttribute('stroke-opacity') == '1')
			element.removeAttribute('stroke-opacity');
		if (element.getAttribute('stroke-width') == '1')
			element.removeAttribute('stroke-width');
		if (element.getAttribute('rx') == '0')
			element.removeAttribute('rx')
		if (element.getAttribute('ry') == '0')
			element.removeAttribute('ry')
	}

	var addSvgElementFromJson = function(data) {
		return canvas.updateElementFromJson(data)
	}

	// // end svgToString()

// public events
	// call this function to set the selected element
	// call this function with null to clear the selected element
	var selectElement = function(newSelected) 
	{
		if (selected == newSelected) return;
		
		// remove selected outline from previously selected element
		if (selected != null && selectedOutline != null) {
			// remove from DOM and store reference in JS (but only if it actually exists)
			try {
				var theOutline = svgroot.removeChild(selectedOutline);
				selectedOutline = theOutline;
			} catch(e) { }
		}
		
		selected = newSelected;
		
		if (selected != null) {
			// we create this element for the first time here
			if (selectedOutline == null) {
				selectedOutline = addSvgElementFromJson({
					"element": "rect",
					"attr": {
						"id": "selectedBox",
						"fill": "none",
						"stroke": "blue",
						"stroke-width": "1",
						"stroke-dasharray": "5,5",
						"width": 1,
						"height": 1,
						// need to specify this style so that the selectedOutline is not selectable
						"style": "pointer-events:none",
					}
				});
				
			}
			
		
		}
		
		call("selected", selected);
	}
	


	var mouseDown = function(evt)
	{
		var x = evt.pageX - container.offsetLeft;
		var y = evt.pageY - container.offsetTop;
		switch (current_mode) {
			case "select":
				started = true;
				start_x = x;
				start_y = y;
				var t = evt.target;
				// WebKit returns <div> when the canvas is clicked, Firefox/Opera return <svg>
				if (t.nodeName.toLowerCase() == "div" || t.nodeName.toLowerCase() == "svg") {
					t = null;
				}
				selected = t;
				//selectElement(t);
				break;
			
		
			case "rect":
				started = true;
				start_x = x;
				start_y = y;
				addSvgElementFromJson({
					"element": "rect",
					"attr": {
						"x": x,
						"y": y,
						"width": 0,
						"height": 0,
						"id": getId(),
						"fill": current_fill,
						"stroke": current_stroke,
						"stroke-width": current_stroke_width,
						"stroke-dasharray": current_stroke_style,
						"stroke-opacity": current_stroke_opacity,
						"fill-opacity": current_fill_opacity,
						"opacity": current_opacity / 2
					}
				});
				break;
			
			
		}
	}

	var mouseMove = function(evt)
	{
		if (!started) return;
		var x = evt.pageX - container.offsetLeft;
		var y = evt.pageY - container.offsetTop;
		var shape = svgdoc.getElementById(getId());
		switch (current_mode)
		{
			case "select":
				// we temporarily use a translate on the element being dragged
				// this transform is removed upon mouseUp and the element is relocated to the
				// new location
				if (selected != null) {
					var dx = x - start_x;
					var dy = y - start_y;
					selected.setAttributeNS(null, "transform", "translate(" + dx + "," + dy + ")");
					//selectedOutline.setAttributeNS(null, "transform", "translate(" + dx + "," + dy + ")");
				}
				break;
	
			// case "select":
			case "rect":
				//shape.setAttributeNS(null, "x", Math.min(start_x,x));
				//shape.setAttributeNS(null, "y", Math.min(start_y,y));
				shape.setAttributeNS(null, "width", Math.abs(x-start_x));
				shape.setAttributeNS(null, "height", Math.abs(y-start_y));
				break;
			
			
			
		}
	}

	var mouseUp = function(evt)
	{
		if (!started) return;

		started = false;
		var element = svgdoc.getElementById(getId());
		var keep = false;
		switch (current_mode)
		{
			case "select":
				if (selected != null) {
					var dx = evt.pageX - container.offsetLeft - start_x;
					var dy = evt.pageY - container.offsetTop - start_y;
					// This fixes Firefox 2- behavior - which does not reset values when
					// the attribute has been removed
					// see https://bugzilla.mozilla.org/show_bug.cgi?id=320622
					selected.setAttribute("transform", "");
					selected.removeAttribute("transform");
				
					switch (selected.tagName)
					{
						
						
						default: // rect
							var x = parseInt(selected.getAttributeNS(null, "x"));
							var y = parseInt(selected.getAttributeNS(null, "y"));
							selected.setAttributeNS(null, "x", x+dx);
							selected.setAttributeNS(null, "y", y+dy);
							break;
					}
					
					// we return immediately from select so that the obj_num is not incremented
					return;
				}
				break;
		
			case "rect":
				keep = (element.getAttribute('width') != 0 ||
				        element.getAttribute('height') != 0);
				break;
			
			
		}
		
		obj_num++;
		//if (!keep && element != null) {
		//	element.parentNode.removeChild(element);
		//	element = null;
		//}
		//else if (element != null) {
		//	element.setAttribute("opacity", current_opacity);
		//	cleanupElement(element);
		//	call("changed",element);
		//}
	}

// public functions




	this.getMode = function() {
		return current_mode;
	}

	this.setMode = function(name) {
		current_mode = name;
	}

	//
	this.updateElementFromJson = function(data) {
		var shape = svgdoc.getElementById(data.attr.id);
		// if shape is a path but we need to create a rect/ellipse, then remove the path
		if (shape && data.element != shape.tagName) {
			svgroot.removeChild(shape);
			shape = null;
		}
		if (!shape) {
			shape = svgdoc.createElementNS(svgns, data.element);
			svgroot.appendChild(shape);
		}
		assignAttributes(shape, data.attr);
		cleanupElement(shape);
		return shape;
	}


	
	$(container).mouseup(mouseUp);
	$(container).mousedown(mouseDown);
	$(container).mousemove(mouseMove);



	this.selectNone = function() {
		selectElement(null);
	}

	

	

}




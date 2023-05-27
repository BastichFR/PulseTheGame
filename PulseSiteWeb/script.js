// Set an offset for scroll
var offsetY = 0;
// Select the div with light id (there is only one div with this id per page)
var mouselight = document.getElementById('light');


// When the page is loaded
// Replace all paragraphs by themselves but every words are in span
// It aims to create a dynamic hover light effect
document.addEventListener('DOMContentLoaded', function ()
{
	var arrayParagraph, strParagraph, i;
	// Get all p element in the document (file) and convert it to an array
	Array.from(document.getElementsByTagName('p')).forEach(function (pg)
	{
		// Split the string
		arrayParagraph = pg.innerHTML.split(' ');
		strParagraph = "";
		i = 0;
		while (i < arrayParagraph.length)
		{
			// Transform words into span words
			// Detect link
			if (arrayParagraph[i] == "<a")
			{
				strParagraph += "<span>" + arrayParagraph[i] + " " + arrayParagraph[i+1] + "</span> ";	
				i++;
			}
			else
			{
				strParagraph += "<span>" + arrayParagraph[i] + "</span> ";
			}

			i++;
		}

		// Replace the current paragraph by itself with every words being span words
		pg.innerHTML = strParagraph;
	})
});

// Detect scroll
window.addEventListener('scroll', function ()
{
	offsetY = window.scrollY;
});

// document.documentElement is the root element
// Add a listener on mouse move (keep track of)
// Use an anonymous function that change css style of the element mouselight
document.documentElement.addEventListener('mousemove', function (mouse)
{
	// clientX and clientY give the mouse position relatively to the window
	mouselight.style.setProperty("top", (mouse.clientY + offsetY - 40) + 'px');
	mouselight.style.setProperty("left", (mouse.clientX - 40) + 'px');
});
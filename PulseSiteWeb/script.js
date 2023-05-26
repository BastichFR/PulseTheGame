// Select the div with light id (there is only one div with this id per page)
var offsetY = 0;
var mouselight = document.getElementById('light');


window.addEventListener('scroll', function () {
	offsetY = window.scrollY;
})
// document.documentElement is the root element
// Add a listener on mouse move (keep track of)
// Use an anonymous function that change css style of the element mouselight
document.documentElement.addEventListener('mousemove', function (mouse)
{
	// clientX and clientY give the mouse position relatively to the window
	mouselight.style.setProperty("top", (mouse.clientY + offsetY - 40) + 'px');
	mouselight.style.setProperty("left", (mouse.clientX - 40) + 'px');
});
/*global window, XMLHttpRequest*/
window.SeleniumTesting = window.SeleniumTesting || {};

window.SeleniumTesting.jQueryVersion = '1.9.1';
window.SeleniumTesting.jQuerySource = [
	"http://ajax.googleapis.com/ajax/libs/jquery/[jQueryVersion]/jquery.min.js",
	"http://ajax.aspnetcdn.com/ajax/jQuery/jquery-[jQueryVersion].min.js",
	"http://code.jquery.com/jquery-[jQueryVersion].min.js"
];

window.SeleniumTesting.Intiliaze = function () {
	if (window.SeleniumTesting.CheckjQuery() ||
		window.SeleniumTesting.LoadjQuery(window.SeleniumTesting.jQuerySource[0]) ||
		window.SeleniumTesting.LoadjQuery(window.SeleniumTesting.jQuerySource[1]) ||
		window.SeleniumTesting.LoadjQuery(window.SeleniumTesting.jQuerySource[2])) {
		window.SeleniumTesting.QueryElement = window.jQuery.noConflict(true);
	} else {
		throw "Failed to load jQuery for Selenium testing with version " + window.SeleniumTesting.jQueryVersion;
	}
};

window.SeleniumTesting.LoadjQuery = function (url) {
	var httpRequest = new XMLHttpRequest();
	httpRequest.open('GET', url.replace('[jQueryVersion]', window.SeleniumTesting.jQueryVersion), false);
	httpRequest.send('');
		
	var script = window.document.createElement('script');
	script.type = "text/javascript";
	script.text = httpRequest.responseText;
	window.document.getElementsByTagName('head')[0].appendChild(script);
	var isSuccessful = window.SeleniumTesting.CheckjQuery();

	if (!isSuccessful) {
		window.document.getElementsByTagName('head')[0].removeChild(script);
	}

	return isSuccessful;
};

window.SeleniumTesting.CheckjQuery = function () {
	return (window.jQuery !== undefined && window.jQuery().jquery == window.SeleniumTesting.jQueryVersion);
};

window.SeleniumTesting.IsAjaxFinished = function() {
	return (window.jQuery === undefined || window.jQuery.active == 0);
}

// Invoking the initialization 
window.SeleniumTesting.Intiliaze();
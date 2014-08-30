/*global window*/
window.SeleniumTesting = window.SeleniumTesting || {};

window.onerror = function(errorMessage, url, lineNumber) {
    window.SeleniumTesting.JavaScriptErrors.push(errorMessage + ' (found at "' + url + '", line #' + lineNumber + ')');
};

window.SeleniumTesting.ClearErrors = function() {
    window.SeleniumTesting.JavaScriptErrors = [];
};

window.SeleniumTesting.ClearErrors();
﻿/*global window, document*/
window.SeleniumTesting = window.SeleniumTesting || {};

window.SeleniumTesting.jQueryVersion = '1.9.1';
window.SeleniumTesting.Intiliaze = function () {
    if (window.SeleniumTesting.CheckjQuery() ||
        window.SeleniumTesting.LoadjQuery("http://ajax.googleapis.com/ajax/libs/jquery/[jQueryVersion]/jquery.min.js") ||
        window.SeleniumTesting.LoadjQuery("http://ajax.aspnetcdn.com/ajax/jQuery/jquery-[jQueryVersion].min.js") ||
        window.SeleniumTesting.LoadjQuery("http://code.jquery.com/jquery-[jQueryVersion].min.js")) {
        window.SeleniumTesting.QueryElement = jQuery.noConflict(true);
    } else {
        throw "Failed to load jQuery for Selenium testing with version " + window.SeleniumTesting.jQueryVersion;
    }
};

window.SeleniumTesting.LoadjQuery = function (url) {
    var jq = document.createElement('script');
    jq.src = url.replace('[jQueryVersion]', window.SeleniumTesting.jQueryVersion);
    document.getElementsByTagName('head')[0].appendChild(jq);
    var isSuccessful = window.SeleniumTesting.CheckjQuery();

    if (!isSuccessful) {
        document.getElementsByTagName('head')[0].removeChild(jq);
    }

    return isSuccessful;
};

window.SeleniumTesting.CheckjQuery = function () {
    return (jQuery != 'undefined' && $.fn.jquery == window.SeleniumTesting.jQueryVersion);
};

// Invoking the initialization 
window.SeleniumTesting.Intiliaze();
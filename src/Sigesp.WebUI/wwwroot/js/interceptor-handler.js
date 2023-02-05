$.ajaxSetup({
  beforeSend: function(xhr, setting) {
    const apiKey = localStorage.getItem('ApiKey');
    xhr.setRequestHeader('X-Api-Key', apiKey);
  }
});

// "use strict";
// debugger;
/*
This is the page for which we want to rewrite the User-Agent header.
*/
// let targetPage = "http://localhost:5000/*";

// /*
// Set UA string to Opera 12
// */
// const apiKey = localStorage.getItem('ApiKey');

// /*
// Rewrite the User-Agent header to "ua".
// */
// function rewriteUserAgentHeader(e) {
//   debugger;
//   for (let header of e.requestHeaders) {
//     if (header.name.toLowerCase() === "X-Api-Key") {
      
//       header.value = apiKey;
//     }
//   }
//   return {requestHeaders: e.requestHeaders};
// }

// /*
// Add rewriteUserAgentHeader as a listener to onBeforeSendHeaders,
// only for the target page.

// Make it "blocking" so we can modify the headers.
// */
// debugger;
// var browser;

// if (typeof browser === "undefined") {
//   browser = chrome;
// }

// browser.webRequest.onBeforeSendHeaders.addListener(
//   rewriteUserAgentHeader,
//   {urls: [targetPage]},
//   ["blocking", "requestHeaders"]
// );




// if ('serviceWorker' in navigator) {
//   debugger;
//   window.addEventListener('load', function() {
//     navigator.serviceWorker.register('sw.js').then(function(registration) {
//       console.log('Service worker registered with scope: ', registration.scope);
//     }, function(err) {
//       console.log('ServiceWorker registration failed: ', err);
//     });
//   });
// }
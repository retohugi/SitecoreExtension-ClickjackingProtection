# Clickjacking Protection - a Sitecore Extension

This extension provides basic protection against Clickjacking Attacks (see [Wikipedia](http://en.wikipedia.org/wiki/Clickjacking) for details on what a Clickjack attack is and [OWASP.org](https://www.owasp.org/index.php/Clickjacking_Defense_Cheat_Sheet) for details on different methods of protection against it).

# Features
## Implemented ##
- Sitecore instance default setting for X-Frame-Option Header
- Default setting support for DENY, SAMEORIGIN or empty (X-Frame-Option header)

## Planned ##
- Site-based X-Frame-Option settings
- Page-based X-Frame-Option settings through data template that can be inherited from on pages.
- support for JavaScript based protection (frame breaker)
- automatic browser / feature detection (and fallbacks)
- support for ALLOW-FROM values

## Tested on
* Sitecore 7.0 (but should work with 6.x)

## Installation 
Install via NuGet Gallery
<pre>
  PM> tbd
</pre>

## Build
See [Readme.md in the /build folder](tree/master/build).


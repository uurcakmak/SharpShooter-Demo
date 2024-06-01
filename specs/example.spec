# Example Specification
tags: KocSistem
## KocSistem Test Automation Example
* Open the browser and navigate to "https://www.kocsistem.com.tr"
* Check that the page title is "KoçSistem Teknolojiyi Türkiye'nin Lider Markaları ile Buluşturuyor!"
* Check element by css "button.button__medium.button__primary.button--icon-only"
* Click on element by css "button.button__medium.button__primary.button--icon-only"
* Wait for "1" seconds
* Click on element by css "button.button__medium.button__primary.button--icon-only"
* Wait for "1" seconds
* Scroll to element by "application-form"
* Wait for "1" seconds
* Find element with name "name" and set it's value to "Ugur"
* Find element with name "surname" and set it's value to "Cakmak"
* Find element with name "phone" and set it's value to "5545551234"
* Find element with name "email" and set it's value to "ugur.cakmak@deneme.com.tr"
* Find element with name "workPlace" and set it's value to "KoçSistem"
* Find element with name "degree" and set it's value to "Yazılım Geliştirme Teknoloji Yöneticisi"
* Find element with name "message" and set it's value to "Lunch & Learn deneme mesajıdır. Dikkate almayınız."
* Click on element by id "recaptcha-anchor" inside iframe by selector "iframe[title='reCAPTCHA']"

## Ford Puma Test Automation Example
tags: Ford
* Open the browser and navigate to "https://www.ford.com.tr"
* Check that the page title is "Hayalinizdeki Ford'a Sahip Olmanın Tam Zamanı | Ford Türkiye"
* Find element by selector "a[href='/fiyat-listesi']" and click
* Find element by selector "a[href='/fiyat-listesi/otomobil']" and click
* Wait for "5" seconds
* Find element by selector "div[data-parent='#accordionPriceList2024'][class='panel-heading']" and click
* Wait for "2" seconds
* Find element by selector "div[data-parent='#accordionPriceList2024'][class='panel-collapse collapse show'] button.fop-button.btn-discover" and click
* Wait for "5" seconds
* Close the browser
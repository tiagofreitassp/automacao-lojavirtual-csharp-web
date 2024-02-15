using System;

namespace automacao_lojavirtual_csharp_web.MyStoreVariabels
{
	public class MyStoreVariables
	{
        public string LblSignIn = "login";//ClassName
        public string LblSignOut = "logout";//ClassName
        public string LblDresses = "//li[@class='sfHover']//a[@class='sf-with-ul'][contains(text(),'Dresses')]";//xPath
        public string LblWomen => "Women";//LinkText
        public string LblTShirts => "T-shirts";//LinkText

        public string CampoEmailAddress = "email";//ID
        public string CampoPassword = "passwd";//ID
        public string CampoFirstName = "firstname";//ID
        public string CampoLastName = "lastname";//ID
        public string CampoCompany = "company";//ID
        public string CampoAddress = "address1";//ID
        public string CampoAddressLine2 = "address2";//ID
        public string CampoCity = "city";//ID
        public string CampoState = "id_state";//ID
        public string CampoZipPostalCode = "postcode";//ID
        public string CampoHomePhone = "phone";//ID
        public string CampoMobilePhone = "phone_mobile";//ID
        public string CampoAdditionalInformation = "other";//ID
        public string CampoPleaseAssignAnAddressTitleForFutureReference = "alias";//ID

        public string BtnSignIn = "SubmitLogin";//ID
        public string BtnAddToCart = "add_to_cart";//ID
        public string BtnProceedToCheckout = "//span[contains(text(),'Proceed to checkout')]";//xPath
        public string BtnContinueShopping = "//span[@title='Continue shopping')]";//xPath
        public string BtnShoppingCartSummary_ProceedToCheckout = "//a[@class='button btn btn-default standard-checkout button-medium']";//xPath
        public string BtnAdresses_ProceedToCheckout = "processAddress";//Name
        public string BtnShipping_ProceedToCheckout = "processCarrier";//Name
        public string BtnPayByBankWire = "bankwire";//ClassName
        public string BtnIConfirmMyOrder = "//span[contains(text(),'I confirm my order')]";//xPath
        public string BtnSave = "submitAddress";//ID

        public string IconHome = "home";//ClassName

        public string ImgPrintedDress = "//img[@title='Printed Dress']";//xPath

        public string IframePrintedDress = "fancybox-iframe";//ClassName

        public string CheckboxIAgreeToTheTermOfService = "//input[@id='cgv']";//xPath

        public string TxtMyAccount = "//h1[contains(text(),'My account')]";//xPath
        public string TxtAdresses = "page-heading";//ClassName
        public string TxtOrderSummary = "page-heading";//ClassName
        public string TxtShipping = "//h1[contains(text(),'Shipping:')]";//xPath
        public string TxtOrderConfirmation = "page-heading";//ClassName
        public string TxtYourOrderOnMyStoreIsComplete = "//p[contains(text(),'Your order on My Shop is complete.')]";//xPath
        public string TxtPleaseChooseYourPaymentMethod = "page-heading";//ClassName
        public string TxtShoppingCartSummary = "cart_title";//ID
        public string TxtPrintedDress = "//h1[contains(text(),'Printed Dress')]";//xPath
        public string TxtState_California = "//option[contains(text(),'California')]";//xPath
        public string TxtYourAdresses = "//h1[contains(text(),'Your addresses')]";//xPath
    }
}
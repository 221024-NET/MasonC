import {Selector, t} from 'testcafe'

class LoginPage{
    emailInput = Selector('input#login-email');
    passwordInput = Selector('input#login-password');
    loginPatBtn = Selector('button#loginp');
    loginEmpBtn = Selector('button#logine');

    constructor(){
        //constructor
    }

    async setUserName(userName){ 
        await t.typeText(this.emailInput, userName)
    }

    async setPassword(password){
        await t.typeText(this.passwordInput, password);
    }

    async clickOnPatLoginButton(){
        await t.click(this.loginPatBtn);
    }

    async clickOnEmpLoginButton(){
        await t.click(this.loginEmpBtn);
    }

}

export default new LoginPage();
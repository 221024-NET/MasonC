import { waitForReact } from 'testcafe-react-selectors'
import { Selector, ClientFunction } from 'testcafe'
import HomePage from '../pages/HomePage'
import LoginPage from '../pages/LoginPage'


const loginUrl = 'http://localhost:3000'
const getUrl = ClientFunction(() => window.location.href);


fixture('Login Page')
.page(loginUrl)
.beforeEach(async t => {
    await waitForReact();
});

test('Loading Login Page', async t => {

    await t
    .expect(getUrl()).contains(loginUrl)
    .expect(Selector('#loginp').exists).ok()
    .expect(Selector('#logine').exists).ok()
    .expect(Selector('#registerp').exists).ok()
    .expect(Selector('#registere').exists).ok();
    // LoginPage.clickOnPatLoginButton();
    // await t.wait(5000);
});


test('FORM - Fail Login as Patient', async t => {
    LoginPage.clickOnPatLoginButton();
    await t.click(Selector('#login-button'));
    await t.wait(2000);
    const newUrl = await t.eval(() => document.documentURI);
    await t.expect(newUrl).noteql('http://localhost:3000/dashboardP');
});

test('FORM - Fail Login as Employee', async t => {
    LoginPage.clickOnEmpLoginButton();
    await t.click(Selector('#login-button'));
    await t.wait(2000);
    const newUrl = await t.eval(() => document.documentURI);
    await t.expect(newUrl).notEql('http://localhost:3000/dashboardE');
});

test('FORM - Successfully Login as Patient', async t => {
    LoginPage.clickOnPatLoginButton();
    LoginPage.setUserName('p@p.com');
    await t.wait(2000);
    LoginPage.setPassword('p');
    await t.wait(2000);
    await t.click(Selector('#login-button'));
    await t.wait(2000);
    const newUrl = await t.eval(() => document.documentURI);
    await t.expect(newUrl).eql('http://localhost:3000/dashboardP');
});

test('FORM - Successfully Login as Employee', async t => {
    LoginPage.clickOnEmpLoginButton();
    LoginPage.setUserName('e@e.com');
    await t.wait(2000);
    LoginPage.setPassword('e');
    await t.wait(2000);
    await t.click(Selector('#login-button'));
    await t.wait(2000);
    const newUrl = await t.eval(() => document.documentURI);
    await t.expect(newUrl).eql('http://localhost:3000/dashboardE');
});
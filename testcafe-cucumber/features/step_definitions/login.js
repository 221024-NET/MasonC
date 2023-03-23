const { Given, When, Then, BeforeAll} = require('cucumber');
const Selector = require('testcafe').Selector;

BeforeAll(async function () {
    // await testController
    // .navigateTo('http://the-internet.herokuapp.com/login');
});

Given('I open the login page', async function () {
    await testController
    .navigateTo('http://the-internet.herokuapp.com/login');
});

When('I enter the username {string}', async function(username) {
    let input = Selector('input#username').with({boundTestRun: testController});

    await testController.wait(5000).typeText(input, username);
});

When('I enter the password {string}', async function(password) {

    let input = Selector('input#password').with({boundTestRun: testController});

    await testController.wait(5000).typeText(input, password);
});

When('I click on the login button', async function() {
    let button = Selector('button').with({boundTestRun: testController});

    await testController
    .wait(5000)
    .click(button);
});

Then('A successful message is displayed', async function() {
    let responseCard = Selector('div#flash').with({boundTestRun: testController});

    await testController.wait(5000).expect(responseCard.innerText).contains('You logged into a secure area');
});

Then('A unsuccessful username message is displayed', async function() {
    let responseCard = Selector('div#flash').with({boundTestRun: testController});

    await testController.wait(5000).expect(responseCard.innerText).contains('Your username is invalid!');
});

Then('A unsuccessful password message is displayed', async function() {
    let responseCard = Selector('div#flash').with({boundTestRun: testController});

    await testController.wait(5000).expect(responseCard.innerText).contains('Your password is invalid!');
});
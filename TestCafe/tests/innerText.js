import { Selector } from 'testcafe';

fixture('Getting Started')
    .page('https://devexpress.github.io/testcafe/example');

test.skip('My first test', async t => {
    await t
        .typeText('#developer-name', 'John Smith')
        .wait(3000)
        .click('#submit-button')
        .expect(Selector('#article-header').innerText).eql('Thank you, John Smith!');
});
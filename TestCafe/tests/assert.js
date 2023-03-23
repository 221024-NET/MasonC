import { Selector, ClientFunction} from 'testcafe';

fixture('All Assert API Tests')
.page('https://demoqa.com/elements');

const getWindowLocation = ClientFunction(() => window.location);

test.skip('Deep Equal ', async t => {

    await t.expect(Selector('.header-wrapper').count).eql(6, "Accordion Items Count", { timeout: 2000 });

});

test.skip('NOT Deep Equal ', async t => {

    await t.expect(Selector('.header-wrapper').count).notEql(5, "Accordion Items Count", { timeout: 2000 });

});

test.skip('Ok ', async t => {

    await t.click('#item-0');
    await t.expect(Selector('#submit').exists).ok('This test will validate if the "submit" button exist');

});

test.skip('Not Ok ', async t => {

    await t.expect(Selector('#submit').exists).Ok('This test will validate if the "submit" button exist');

});

test.skip('Contains ', async t => {

    const getLocation = ClientFunction(() => document.location.href.toString());

    await t.expect(getLocation()).contains('https://demoqa.com/elements');

});
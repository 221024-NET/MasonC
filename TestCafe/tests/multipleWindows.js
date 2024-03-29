import { Selector } from 'testcafe';

fixture('New Window Feature')
.page('https://phptravels.net/');

let ytSelector = '';
let url = '';

test.skip('New Window Opened Automatically After Click ', async t => {

    ytSelector = Selector('div.footer-social-box a').nth(2);

    url = await t.eval(() => document.documentURI);
    console.log('Main URL: '+ url);
    await t.expect(url).eql('https://phptravels.net/');

    await t
    .wait(5000)
    .click(ytSelector)

    url = await t.eval(() => document.documentURI);
    console.log('YT URL: '+ url);
    await t.expect(url).eql('https://www.youtube.com/c/PhptravelsOfficial');

  });

test.skip('Multiple Windows', async t => {

    url = await t.eval(() => document.documentURI);
    console.log('Main URL: '+ url);
    await t.expect(url).eql('https://phptravels.net/');

    //This method takes a window descriptor as an argument:
    const initialWindow = await t.getCurrentWindow();

    //-----* Open a new window #2*-----
    //-- NOTE: Browser windows share the client-side storage. Only one user role can be active at a time.--
    await t.openWindow('https://www.youtube.com/');


    url = await t.eval(() => document.documentURI);
    console.log('New Window URL: '+ url);
    await t.expect(url).eql('https://www.youtube.com/');

    //This method takes a window descriptor as an argument
    const window2 = await t.getCurrentWindow();

    //-----* Open a new window #3 *-----
    const window3 = await t.openWindow('http://github.com/');

    url = await t.eval(() => document.documentURI);
    console.log('New Window URL: '+ url);
    await t.expect(url).eql('https://github.com/');

    //-----* Switch between windows *-----
    await t.switchToWindow(initialWindow);

    url = await t.eval(() => document.documentURI);
    console.log('Main URL after switching: '+ url);
    await t.expect(url).eql('https://phptravels.net/');


    //-----* Close opened windows *-----
    await t.closeWindow(window3);
    console.log('Window #3 has been closed')

    await t.closeWindow(window2);
    console.log('Window #2 has been closed')

  });
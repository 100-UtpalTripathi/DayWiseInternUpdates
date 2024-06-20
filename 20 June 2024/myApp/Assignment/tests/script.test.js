const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

test('Login form submission - successful login', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');
    
    // Create a new JSDOM instance
    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const { window } = dom;

    // Append script to the DOM
    const scriptElement = window.document.createElement('script');
    scriptElement.textContent = script;
    window.document.body.appendChild(scriptElement);

    // Set form values for a successful login
    window.document.getElementById('username').value = 'u1';
    window.document.getElementById('password').value = 'p1';

    // Trigger form submission
    const form = window.document.getElementById('loginForm');
    form.dispatchEvent(new window.Event('submit', { bubbles: true, cancelable: true }));

    // Check login message
    const loginMessage = window.document.getElementById('loginMessage').textContent;
    expect(loginMessage).toBe('Login successful!');
});

test('Login form submission - unsuccessful login', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');
    
    // Create a new JSDOM instance
    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const { window } = dom;

    // Append script to the DOM
    const scriptElement = window.document.createElement('script');
    scriptElement.textContent = script;
    window.document.body.appendChild(scriptElement);

    // Set form values for an unsuccessful login
    window.document.getElementById('username').value = 'u4';
    window.document.getElementById('password').value = 'p4';

    // Trigger form submission
    const form = window.document.getElementById('loginForm');
    form.dispatchEvent(new window.Event('submit', { bubbles: true, cancelable: true }));

    // Check login message
    const loginMessage = window.document.getElementById('loginMessage').textContent;
    expect(loginMessage).toBe('Invalid username or password. Please try again.');
});

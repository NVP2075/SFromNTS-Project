
let active = null;

function toggle(panel) {
    if (active === panel) {
        // collapse
        deactivate(panel);
        active = null;
    } else {
        if (active) deactivate(active);
        activate(panel);
        active = panel;
    }
}

function activate(panel) {
    document.getElementById('panel-' + panel).classList.add('active');
    document.getElementById('btn-' + panel).classList.add('active');
    const form = document.getElementById('form-' + panel);
    form.classList.add('visible');
}

function deactivate(panel) {
    document.getElementById('panel-' + panel).classList.remove('active');
    document.getElementById('btn-' + panel).classList.remove('active');
    const form = document.getElementById('form-' + panel);
    form.classList.remove('visible');
    form.reset();
}

function handleSignup(e) {
    e.preventDefault();
    const data = Object.fromEntries(new FormData(e.target));
    alert('Account created for ' + data.name + ' (' + data.email + ')');
}

function handleLogin(e) {
    e.preventDefault();
    const data = Object.fromEntries(new FormData(e.target));
    alert('Welcome back, ' + data.email);
}
const panelLogin = document.getElementById('panelLogin');
const panelSignup = document.getElementById('panelSignup');
const labelLogin = document.getElementById('labelLogin');
const labelSignup = document.getElementById('labelSignup');
const formLogin = document.getElementById('formLogin');
const formSignup = document.getElementById('formSignup');
const divider = document.getElementById('divider');

let current = null;

function openPanel(which) {
    if (current) return;
    current = which;

    divider.classList.add('hidden');
    labelLogin.classList.add('hidden');
    labelSignup.classList.add('hidden');

    if (which === 'login') {
      panelLogin.classList.add('expanded');
      panelSignup.classList.add('active-other');
      setTimeout(() => formLogin.classList.add('visible'), 10);
    } else {
      panelSignup.classList.add('expanded');
      panelLogin.classList.add('active-other');
      setTimeout(() => formSignup.classList.add('visible'), 10);
    }
  }

  function closePanel(e) {
    e.stopPropagation();
    if (!current) return;

    formLogin.classList.remove('visible');
    formSignup.classList.remove('visible');

    setTimeout(() => {
      panelLogin.classList.remove('expanded', 'active-other');
      panelSignup.classList.remove('expanded', 'active-other');

      setTimeout(() => {
        labelLogin.classList.remove('hidden');
        labelSignup.classList.remove('hidden');
        divider.classList.remove('hidden');
        current = null;
      }, 700);
    }, 200);
  }
  
  
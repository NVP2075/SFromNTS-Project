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

async function login() {
    let AccountName = document.getElementById('loginUserAccount').value;
    let Password = document.getElementById('loginPass').value;
    let data = {
        AccountName: AccountName,
        Password: Password
    }
    if (AccountName == null || Password == null) {
        alert("Vui lòng điền thông tin đăng nhập");
        return;
    }
    else {
        let response = await fetch('/UserAccount/Login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });
        let result = await response.json();

        if (result.response == true) {
            alert(result.message);
            window.location.href = '/UserAccount/LoginAndSignupForm';
        }
        else {
            alert(result.message);
        }
    }

}
async function signUp()
{
    let termsConfirm = document.getElementById('terms');
    let AccountName = document.getElementById('signupAccountName').value;
    let Email = document.getElementById('signupEmail').value;
    let Password = document.getElementById('signupPass').value;
    let Username = document.getElementById('signupName').value;
    let UserSurname = document.getElementById('signupSurname').value;
    let DateOfBirth = document.getElementById('signupDOB').value;
    let Occupation = document.getElementById('signupOcupation').value;
    let data = {
        AccountName: AccountName,
        Email: Email,
        Password: Password,
        Username: Username,
        UserSurname: UserSurname,
        DateOfBirth: DateOfBirth,
        Occupation: Occupation
    };

   
    if (AccountName == null || Email == null || Password == null || Username == null || UserSurname == null || DateOfBirth == null || Occupation == null) {
        alert("Vui lòng điền đầy đủ thông tin")
        return;
    }
    else {
        if (!termsConfirm.checked) {
            alert("Vui lòng chấp nhận điều khoản sử dụng!");
            return;
        }
        else if (termsConfirm.checked) {
            let response = await fetch('/UserAccount/SignUp', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(data)
            });
            let result = await response.json();

            if (result.response==true && termsConfirm.checked) {
                alert(result.message);
                window.location.href = '/UserAccount/LoginAndSignupForm';
            }
            else {
                alert(result.message);
                window.location.href = '/UserAccount/LoginAndSignupForm';
            }
        }
    }
    
}
       
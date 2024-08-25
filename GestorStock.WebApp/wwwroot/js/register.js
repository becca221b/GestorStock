(function () {
    'use strict'
    const forms = document.querySelectorAll('.requires-validation')
    Array.from(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                const password = form.querySelector('input[name="password"]');
                const confirmPassword = form.querySelector('input[name="confirm"]');

                // Validación personalizada para comparar contraseñas
                if (password.value !== confirmPassword.value) {
                    event.preventDefault();
                    event.stopPropagation();

                    confirmPassword.setCustomValidity('Passwords do not match');
                } else {
                    confirmPassword.setCustomValidity(''); // Limpia el mensaje de error si coinciden
                }
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()
(() => {
    const components = () => {
        return {
            form: document.getElementsByTagName('form')[0],
            nombres: document.getElementById('nombres').value,
            apellidoPaterno: document.getElementById('apellidoPaterno').value,
            apellidoMaterno: document.getElementById('apellidoMaterno').value,
            fechaNacimiento: document.getElementById('fechaNacimiento').value,
            nivelEducativo: document.getElementById('nivelEducativo').value,
            numeroCelular: document.getElementById('numeroCelular').value,
            messages: document.getElementById('message')
        }
    }

    const { form } = components();

    form.addEventListener('submit', async (e) => {

        e.preventDefault();

        const { apellidoMaterno, apellidoPaterno, fechaNacimiento, nivelEducativo, nombres, numeroCelular, messages } = components();
        const requestData = {
            Nombres: nombres,
            ApellidoPaterno: apellidoPaterno,
            ApellidoMaterno: apellidoMaterno,
            FechaNacimiento: fechaNacimiento,
            NivelEducativo: nivelEducativo,
            NumeroCelular: numeroCelular,
        }

        const requestHeaders = new Headers();

        requestHeaders.append('Accept', 'application/json');
        requestHeaders.append('Content-Type', 'application/json');

        const fetchResponse = await fetch(form.action, { method: 'POST', body: JSON.stringify(requestData), headers: requestHeaders });
        const textResponse = await fetchResponse.json();
        const { message, success } = textResponse;

        messages.setAttribute('class', success ? 'alert alert-success' : 'alert alert-danger');
        messages.innerText = message;
    });
})();
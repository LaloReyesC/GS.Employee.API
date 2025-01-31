(() => {
    const components = () => {
        return {
            form: document.getElementsByTagName('form')[0],
            btnEliminar: document.getElementById('btnDelete'),
            listUrl: document.getElementById('listUrl').value,
            deleteUrl: document.getElementById('deleteUrl').value,
            id: document.getElementById('id').value,
            estatus: document.getElementById('estatus').checked,
            nombres: document.getElementById('nombres').value,
            apellidoPaterno: document.getElementById('apellidoPaterno').value,
            apellidoMaterno: document.getElementById('apellidoMaterno').value,
            fechaNacimiento: document.getElementById('fechaNacimiento').value,
            nivelEducativo: document.getElementById('nivelEducativo').value,
            numeroCelular: document.getElementById('numeroCelular').value,
            messages: document.getElementById('message')
        }
    }

    const { form, btnEliminar, deleteUrl } = components();

    form.addEventListener('submit', async (e) => {

        e.preventDefault();

        const { apellidoMaterno, apellidoPaterno, fechaNacimiento, nivelEducativo, nombres, numeroCelular, messages, id, estatus } = components();
        const requestData = {
            id,
            estatus,
            nombres,
            apellidoPaterno,
            apellidoMaterno,
            fechaNacimiento,
            nivelEducativo,
            numeroCelular,
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

    btnEliminar.addEventListener('click', async (e) => {

        e.preventDefault();

        const deleteItem = confirm('Estas seguro que deseas eliminar el registro?');

        if (!deleteItem) {
            return;
        }
        const { id, messages, listUrl } = components();
        const url = `${deleteUrl}/${id}`;

        const fetchResponse = await fetch(url, { method: 'DELETE' });
        const textResponse = await fetchResponse.json();
        const { message, success } = textResponse;

        messages.setAttribute('class', success ? 'alert alert-success' : 'alert alert-danger');
        messages.innerText = message;

        if (success) {
            setTimeout(() => {
                window.location.href = listUrl;
            }, 2000);
        }
    });
})();
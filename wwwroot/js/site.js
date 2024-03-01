const dataInput = document.getElementById('data');
const options = {
    autohide: true,
    format: 'dd/mm/yyyy',
    language: 'it',
    todayButton: new Date()
};
const picker = new Datepicker(dataInput, options);
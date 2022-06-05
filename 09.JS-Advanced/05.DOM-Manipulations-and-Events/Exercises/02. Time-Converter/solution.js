function attachEventsListeners() {

    let daysInputRef = document.getElementById('days');
    let hoursInputRef = document.getElementById('hours');
    let minutesInputRef = document.getElementById('minutes');
    let secondsInputRef = document.getElementById('seconds');

    document.getElementById('daysBtn').addEventListener('click', e => {
        let days = Number(daysInputRef.value);

        hoursInputRef.value = days * 24;
        minutesInputRef.value = Number(hoursInputRef.value) * 60;
        secondsInputRef.value = Number(minutesInputRef.value) * 60;
    });

    document.getElementById('hoursBtn').addEventListener('click', e => {
        let hours = Number(hoursInputRef.value);

        daysInputRef.value = hours / 24;
        minutesInputRef.value = hours * 60;
        secondsInputRef.value = Number(minutesInputRef.value) * 60;
    });

    document.getElementById('minutesBtn').addEventListener('click', e => {
        let minutes = Number(minutesInputRef.value);

        secondsInputRef.value = minutes * 60;
        hoursInputRef.value = minutes / 60;
        daysInputRef.value = Number(hoursInputRef.value) / 24;
    });

    document.getElementById('secondsBtn').addEventListener('click', e => {
        let seconds = Number(secondsInputRef.value);

        minutesInputRef.value = seconds / 60;
        hoursInputRef.value = Number(minutesInputRef.value) / 60;
        daysInputRef.value = Number(hoursInputRef.value) / 24;
    });
}
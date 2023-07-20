// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var timer = new Timer();

const { createApp, ref, reactive } = Vue;



var app = createApp({

    setup() {

        const jobitem_found = ref(false);
        const IsWorkDone = ref(false);
        const orderId_error = ref(false);

        const JobName = ref("");
        const Detail = ref("");
        const Time = ref("");
        const JobID = ref(0);
        const WorkDone = ref("");
        const OrderId = ref(0);        

        return {
            jobitem_found,
            JobName,
            Detail,
            Time,
            JobID,
            WorkDone,
            IsWorkDone,
            orderId_error
        }

    },
    watch: {
    },
    methods:
    {
        FindJob() {
            var number = $('#productOrderNumber').val();

            this.OrderId = number;

            var data = { id: number };

            $.post("/Production/FindJob", data, function (data) {

                if (data.error == false) {
                    app_root.JobID = data.id;
                    app_root.JobName = data.jobname;
                    app_root.Detail = data.detail;
                    app_root.Time = data.time;
                    app_root.jobitem_found = true;
                    app_root.orderId_error = false
                }
                else {
                    app_root.orderId_error = true;
                    app_root.jobitem_found = false;
                }
            });

           
        },

        StartTimer() {
            timer.start();

            var data = { orderId: this.OrderId };

            $.post("/Production/SubmitJobTime", data);

            timer.addEventListener('secondsUpdated', function (e) {
                app_root.Time = timer.getTimeValues().toString(); 
            });

        },
        StopTimer() {
            timer.stop();
            this.IsWorkDone = true;

    

        },
        SubmitJob() {

            var data = { orderId: this.OrderId, time: this.Time, workdone: $('#workdone').val() };

            $.post("/Production/SubmitJob", data, function (data) {
                if (data.ok == true) {

                }
            });

        }
      
    }
});


var app_root = app.mount('#app')
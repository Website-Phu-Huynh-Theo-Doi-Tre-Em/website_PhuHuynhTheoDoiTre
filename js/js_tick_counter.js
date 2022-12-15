var a_displayFormat = "%_d% Days, %_h% Hours, %_m% Minutes, %_s% Seconds.";
var a_countStepper = 1;
var a_leadingZero = true;
var a_timeout_period = 1000;

var a_timer;

var projects = {

	start : function(secs, timer_id)
	{
		this.showTimer(secs, timer_id);

		this.a_secs = secs + a_countStepper;
		a_timer = setTimeout("projects.start(" + (this.a_secs) + "," + '"'+timer_id+'"' + ")", a_timeout_period);
	},
	
	stop : function(timer_id, project_id)
	{
		clearTimeout(a_timer);
	},
	
	convertTime : function(secs, num1, num2)
	{
		var s = ((Math.floor(secs / num1)) % num2).toString();
		if (a_leadingZero && s.length < 2)
			s = "0" + s;
		return "<b>" + s + "</b>";
	},
	
	showTimer : function(secs, timer_id)
	{
		var a_display_str = a_displayFormat;
		
		a_display_str = a_display_str.replace(/%_d%/g, this.convertTime(secs, 86400, 100 * 365));
		a_display_str = a_display_str.replace(/%_h%/g, this.convertTime(secs, 3600, 24));
		a_display_str = a_display_str.replace(/%_m%/g, this.convertTime(secs, 60, 60));
		a_display_str = a_display_str.replace(/%_s%/g, this.convertTime(secs, 1, 60));

		var output = document.getElementById(timer_id);
		output.innerHTML = a_display_str;
	}
};
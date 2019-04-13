$('.tts').bind('click', function(e){
  e.preventDefault();
  var txt = $(this).attr('data-text');
  var synth = window.speechSynthesis;
  var textUtter = new SpeechSynthesisUtterance(txt);
  textUtter.lang= 'fr-FR';
  synth.speak(textUtter);
});
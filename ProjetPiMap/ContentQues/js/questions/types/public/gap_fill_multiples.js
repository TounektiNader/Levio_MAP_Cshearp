$('a[id^="correct-gap_fill_multiples"]').on('click', function(){
  console.log('Click gap_fill_multiples');
  var question_id = $(this).attr('data-id');
  $('#feedback-gap_fill_multiples-' + question_id).html('');
  $('.correct-gap_fill_multiples-' + question_id).each(function(){
    console.log('gap_fill');

    console.log( $(this).attr('data-feedback') );

    console.log( typeof $(this).attr('data-feedback') );

    var feedback = ( $(this).attr('data-feedback') != '' ) ? ' : ' + $(this).attr('data-feedback') : '';

    if( $(this).is(":checked") && $(this).attr('data-correct') != 1 ){
      console.log('Incorrect');
      $('#feedback-gap_fill_multiples-' + question_id).append( '<div class="alert alert-danger" role="alert"><strong>' + $(this).attr('data-choice') + '</strong>' +  feedback + '</div>');
    }else if( $(this).is(":checked") && $(this).attr('data-correct') == 1 ){
      console.log('Correct');
      $('#feedback-gap_fill_multiples-' + question_id).append( '<div class="alert alert-success" role="alert"><strong>' + $(this).attr('data-choice') + '</strong> : ' +  correct_answer + '</div>');
    }

  });
});

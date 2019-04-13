// function trimSpaces(str) {
//     return str.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
// }

// $(function() {
// 	/*
// 	$("#sortableDeuxColonnes").sortable({
//         revert: true
//     });
//     */
   
//     $("[id^='sortableDeuxColonnes']").sortable({
//         revert: true
//     });
	
// 	$('#correction').click(function(){
	
// 		var reponses = $('#answer').text();			
// 		reponses = reponses.split(';');
		
// 		$('#sortableDeuxColonnes div').each(function(index) {
// 			if( $(this).attr('id') == reponses[index] ){
// 				//console.log('Bonne reponse');
// 				$(this).removeClass('ui-state-default').addClass('ui-state-highlight');
// 			}
// 			else{
// 				//console.log('Mauvaise reponse');
// 				$(this).removeClass('ui-state-highlight').addClass('ui-state-default');
// 			}
// 		});
// 	});
	
// });

// $(function() {
// 	$( "#sortable" ).sortable();
// 	$( "#sortable" ).disableSelection();
	
// 	$('#correction').click(function(){
	
// 		var reponsesUtilisateur = new Array();
		
// 		var reponses = $('#answer').text();			
// 		reponses = reponses.split(';');
		
// 		var correct = 'Correct';
// 		var incorrect = 'Incorrect';
		
// 		$('ul#sortable li').each(function(index) {
// 			reponsesUtilisateur.push( $(this).attr('id') );
// 			if( reponsesUtilisateur[index] == reponses[index] ){
// 				$(this).find('span').text(correct);
// 				$(this).removeClass('ui-state-default').addClass('ui-state-highlight');
// 				$(this).attr('data-icon', 'check');
// 			}
// 			else{
// 				$(this).find('span').text(incorrect);
// 				$(this).removeClass('ui-state-highlight').addClass('ui-state-default');
// 			}
// 		});
// 		//console.log(reponsesUtilisateur);
// 		//console.log(reponses);
		
// 	});
	
// });

// $(".validationExercice").click(function(event){
//     event.preventDefault();

//     var idExercice = $(this).attr('id');
//     //console.log(idExercice);
    
//     var type = $('#type-' + idExercice).text();
//     //console.log(type);
    
//     if( type == "qcmReponsesMultiples" )
//     {

//     	console.log('New version');

// 	   var element_id = 0;
// 	   var iterator_index = 0;
	   
//        $('input[name*=qcmrm-' + idExercice + ']').each(function(index){
           
//            var checked = $(this).is(':checked');
           
//            if( index == 0 ){
//            	element_id = $(this).attr('id');
//            }else{
//            	if( element_id != $(this).attr('id') ){
//            		element_id = $(this).attr('id');
//            		iterator_index = 0;
//            		$('#feedBack-' + idExercice).append('<br />');
//            	}
//            }

//            if( $(this).val() == 1 && checked){

// 				console.log('Reponse correcte');
//                  $('#label-' + idExercice + '-' + element_id + '-' + iterator_index).addClass('correctAnswerMini');
                
//             }else if($(this).val() != 1 && checked){
            	
//             	console.log('Reponse incorrecte');
//                 $('#label-' + idExercice + '-' + element_id + '-' + iterator_index).addClass('incorrectAnswerMini');
//                 $('#proposition-' + idExercice + '-' + element_id + '-' + iterator_index).css('color', 'red');

//             }else if( $(this).val() == 1 && ! checked ){

// 				console.log('Reponse manquante');
//                 // $('#label-' + idExercice + '-' + element_id + '-' + iterator_index).addClass('incorrectAnswerMini');
//                 $('#proposition-' + idExercice + '-' + element_id + '-' + iterator_index).css('color', 'orange');
//                 var proposition = $('#proposition-' + idExercice + '-' + element_id + '-' + iterator_index).text();
//                 $('#feedBack-' + idExercice).append('<img src="http://res.cloudinary.com/bdf/image/upload/v1421250242/1421271827_warning_vh9hxd.png" /> Vous auriez dû sélectionner : <span style="color:orange;">"' + proposition + '"</span><br />');
                
//             }
//             iterator_index++;
//        }); 
//     }
//     if( type == "qcmReponseUnique" ){
    
//         var idQuestions = {};
//         $.each($('#' + idExercice).serializeArray(), function(i, field) {
//             idQuestions[field.name] = field.value;
//             if( field.value == 1 ){
//                 $('div#' + field.name).addClass('correctAnswerMini');  
//             }else{
//                 $('div#' + field.name).addClass('incorrectAnswerMini');  
//             }
//         });    
//     }
//     if( type == "vraiFaux" ){
//         var idQuestions = {};
//         $.each($('#' + idExercice).serializeArray(), function(i, field) {
//             idQuestions[field.name] = field.value;
//             //console.log(field.name);
//             //console.log(field.value);
//             if( field.value == "correct" ){
//                 $('div#' + field.name).addClass('correctAnswerMini');  
//             }else{
//                 $('div#' + field.name).addClass('incorrectAnswerMini');  
//             }
//         });
//     }
//     if( type == "associationsDeuxColonnes" ){
        
//         var reponsesUtilisateur = new Array();
        
//         var nombreReponses = $('#nombreVignettesAssociation-' + idExercice).text();  
//         //console.log(nombreReponses);
//         var reponses = new Array();
        
//         for(var i=0;i<nombreReponses;i++){
//             reponses.push(i);
//         }
        
//         console.log(reponses);
        
//         var correct = 'Correct';
//         var incorrect = 'Incorrect';
        
//         $('ul#sortableDeuxColonnes' + idExercice + ' li').each(function(index) {
//             reponsesUtilisateur.push( $(this).attr('id') );
//             console.log('Reponse utilisateur : ' + reponsesUtilisateur[index]);
//             if( reponsesUtilisateur[index] == reponses[index] ){
//                 $(this).removeClass('ui-state-default').addClass('correctAnswerMini');
//             }
//             else{
//                 $(this).removeClass('ui-state-default').addClass('incorrectAnswerMini');
//             }
//         });
//         console.log(reponsesUtilisateur);
//         console.log(reponses);
        
//     }
//     if( type == "texteLacunaireReponseLibre" ){
//         //console.log('Dans la boucle');
//         $('.reponsesTexteLacunaire-' + idExercice).each(function(index){
            
//             if( $(this).val() == '' ){
// 				$(this).val('___')
//                 //return false;
//             }
            
//             //console.log( $(this).val() );
//             var reponseUtilisateur = trimSpaces( $(this).val() );
//             var id = $(this).attr('id');
//             id = id.split('-');
//             var idQuestion = id[1];
//             id = id[2];
//             //console.log( id );
//             var reponse = $("#reponse-" + idExercice + "-" + idQuestion + "-" + id).text();
//             //console.log( reponse );
//             if( reponseUtilisateur == reponse ){
//                 //console.log( 'Bonne reponse' );
//                 $(this).css("color", "green");
//             }
//             else{
//                 //console.log( 'Mauvaise reponse' );
//                 var feedBack = '<span style="color:red;text-decoration:underline;">' + reponseUtilisateur + '</span> -> <span style="color:green;">' + reponse + '</span><br />';
//                 $('#feedBack-' + idExercice).append(feedBack);
//                 $(this).css("color", "red");
//             }
//         });
//     }
// 	if( type == "exerciceConjugaison" ){
// 		var number_of_verb = 0;
// 		var number_of_error = 0;
// 		var feedback = '<ul>';
		
// 		$( "select.exercice-conjugaison-" + idExercice + " option:selected" ).each(function() {
// 			if( $(this).data('correct') == 1 )
// 			{
// 				$(this).parent().css({background : "#00CC00"});
// 			$(this).parent().attr('disabled', 'disabled');
// 			}else{
// 				feedback += '<li>Vous avez choisi <strong>' + $(this).val() + '</strong> mais la conjugaison correcte était <strong>' + $(this).parent().next().text() + '</strong></li>';
// 			$(this).parent().css({background : "#FF0000"});
// 			$(this).parent().attr('disabled', 'disabled');
// 					number_of_error++;
// 				}
// 				number_of_verb++;
// 		});
		
// 		if( number_of_error == 0 )
// 		{
// 			feedback += '<li>Bravo, vous n\'avez pas fait d\'erreur !</li>';
// 		}else{
// 			feedback += 'Votre score est de ' + (number_of_verb - number_of_error) + ' / ' + number_of_verb + '.';
// 		}
		
// 		feedback += '</ul>';
		
// 		console.log( '#feedBack-' + idExercice );
		
// 		$('#feedBack-' + idExercice).html(feedback);
// 	}
    
//     if( type == "texteLacunaireReponsesMultiples" ){
// 		var number_of_questions = 0;
// 		var number_of_error = 0;
// 		var feedback = '<ul>';
		
		
// 		$( "select.exercice-texteLacunaireReponsesMultiples-" + idExercice + " option:selected").each(function(){
// 			if( $(this).val() == 1 ){
// 					$(this).parent().css({background : "#00CC00"});
// 					$(this).parent().attr('disabled', 'disabled');
// 			}else{
// 				feedback += '<li>Vous avez choisi <strong>' + $(this).text() + '</strong> mais l\'option correcte était <strong>' + $(this).parent().children('option[value=1]').text() + '</strong></li>';
// 				$(this).parent().css({background : "#FF0000"});
// 				$(this).parent().attr('disabled', 'disabled');
// 				number_of_error++;
// 			}
			
// 			number_of_questions++;
// 		});
		
// 		if( number_of_error == 0 ){
// 			feedback += '<li>Bravo, vous n\'avez pas fait d\'erreur !</li>';
// 		}else{
// 			feedback += 'Votre score est de ' + (number_of_questions - number_of_error) + ' / ' + number_of_questions + '.';
// 		}
			
// 		feedback += '</ul>';
		
// 		//
// 		console.log( '#feedBack-' + idExercice );
// 		$('#feedBack-' + idExercice).html(feedback);
		
// 	}
    
//     $(this).attr('disabled', 'disabled');
    
    

// });

// $(document).ready(function(){
//     $(".typesQuestions").click(function(event) {
//         event.preventDefault();
//         var url = $(this).attr('href');
//         //console.log(url);
//         $('#zoneCreationQuestion').load(url); 
//     });
    
//     $('#typesQuestions').hide();
    
//     $('#ajouterQuestion').click(function(){
//         $('#typesQuestions').toggle();
//     });
    
//     $('.bloc_exo table').before('<div class="clearfix"></div>').addClass("table table-bordered");
    
//     $("[rel=tooltip]").tooltip();
     
// });

// $(function(){
//   // bind change event to select
//   $('#languageSelector').bind('change', function () {
//       var url = $(this).val(); // get selected value
//       if (url != "null" ) { // require a URL
//           window.location = url; // redirect
//       }
//       return false;
//   });
// });

// $(document).ready(function() {
//     $('#redactor_content').redactor();
//     $('#redactor_content2').redactor();
//   //   $( "#accordion" ).accordion({
// 		// heightStyle: "content",
// 		// disabled: true
//   //   });
//  //    $('body').wordsmith({
//  //    	maxWordLength: 20, 
// 	//     popupWidth: 920, 
// 	//     popupHeight: 450,
// 	//     lookupImage: "http://azurlingua.webstore.fr/dev/exercices/img/question_mark.png",
// 	//     lookupMessage: 'Cliquez sur un mot pour obtenir sa définition',
// 	//     lookupUrl: 'http://www.cnrtl.fr/definition/{word}'
// 	// });
// });

// $(document).ready(function(){
    
//     var idProposition = 0;
//     var premierClick = 0;
//     var propositions = new Array();
    
//     $('#ajouterProposition').click(function(event){
    
//         if( premierClick == 0 ){
//             var header = '<tr><th>Proposition</th><th>Correcte ?</th><th>Valider</th><th>Suppression</th></tr>';
//             $('#listePropositions').append(header);
//         }
        
//         event.preventDefault();
//         var proposition = '<tr id="containerProposition' +  idProposition + '"><td><input class="input-xxlarge" type="text" id="proposition-' + idProposition + '" /></td><td><input id="checkbox-' + idProposition + '" type="checkbox" name="correct" /></td><td><button class="validate_proposition" id="validation-' + idProposition + '">Valider</button></td><td><button class="remove_proposition" id="suppression-' + idProposition + '">Supprimer</button></td></tr>';
//         $('#listePropositions').append(proposition);
//         idProposition++;
//         premierClick++;
//     });
    
//     $(document).on('click','.remove_proposition',function(event){
//         event.preventDefault();
//         var id = $(this).attr('id');
//         id = id.split('-');
//         id = id[1];
//         $('#containerProposition' + id + '').remove();
//         idProposition--;
//         $('#nombrePropositions').val(idProposition);
//     });
    
//     $(document).on('click','.remove_proposition',function(event){
//         event.preventDefault();
//         var id = $(this).attr('id');
//         id = id.split('-');
//         id = id[1];
//         $('#containerProposition' + id + '').remove();
//         idProposition--;
//         $('#nombrePropositions').val(idProposition);
//     });
    
//     $(document).on('click','.validate_proposition',function(event){
//         event.preventDefault();
//         var id = $(this).attr('id');
//         id = id.split('-');
//         id = id[1];
//         //console.log(id);
//         var contenu = $('#proposition-' + id).val();
//         var correct = $('#checkbox-' + id).is(':checked');
//         //console.log(contenu);
//         //console.log(correct);
//         var temp = new Array();
//         temp.push(contenu);
//         temp.push(correct);
//         propositions.push(temp);
//         //console.log(propositions);
        
//         //console.log( toJson(propositions) );
        
//         $('#propositions').val( toJson(propositions) );
//     });
    
//     function addslashes(str) {
// 	     str=str.replace(/\'/g,'\\\'');
// 	     str=str.replace(/\"/g,'\\"');
// 	     str=str.replace(/\\/g,'\\\\');
// 	     str=str.replace(/\0/g,'\\0');
// 	     return str;
// 	}
    
//     function toJson(array){
        
//         var i = 0;
//         var jsonOutput ='[';
        
//         for(i=0;i<array.length;i++){
//             var j = i+1;
//             var k = i+2;
//             if( j != array.length ){
//                 jsonOutput += '{"libelle" : "' + addslashes(array[i][0]) + '", "correct" : "' + array[i][1] +'"},';
//             }else{
//                 jsonOutput += '{"libelle" : "' + addslashes(array[i][0]) + '", "correct" : "' + array[i][1] +'"}';
//             }
            
//         }
        
//         jsonOutput += ']';
        
//         return jsonOutput;
//     }
    
// });

// $(document).ready(function(){
//     $("a[rel='prettyPhoto']").prettyPhoto();
// });

//Expressions idiomatiques
$(function(){
	
	$('#flipbox').parent().removeClass('span6').addClass('col-md-4');
	$('#text-image').parent().removeClass('span5').addClass('col-md-4');

	var found = $("body").find("#sensPropreButton");
	if (found.length != 0) {
		$('#accordion').hide();
	}
	
	var figure = $('#figure').html();
	var propre = $('#propre').html();
	var textFigure = $('#text-figure').html();
	var textPropre = $('#text-propre').html();
	
	// console.log(propre);

	$('#flipbox').html(figure);		
	$('#sensFigureButton').hide();
	$('#text-image').html(textFigure);
	
	function showPropre(){
		console.log('showPropre');
		$('#sensFigureButton').show();
		$('#sensPropreButton').hide();
		$('#text-image').html(textPropre);
		console.log(textPropre);
		$('#accordion').show('slow');
	}
	
	function showFigure(){
		console.log('showFigure');
		$('#sensFigureButton').hide();
		$('#sensPropreButton').show();
		$('#text-image').html(textFigure);
		console.log(textFigure);
		$('#accordion').show('slow');
	}
	
	$("button.sensPropre").bind("click",function(){
		var $this = $(this);
		$("#flipbox").flip({
			direction: $this.attr("rel"),
			color: $this.attr("rev"),
			content: propre,
			onBefore: function(){$(".revert").show()},
			onEnd: showPropre()
		})
		return false;
	});

	$("button.sensFigure").bind("click",function(){
		var $this = $(this);
		$("#flipbox").flip({
			direction: $this.attr("rel"),
			color: $this.attr("rev"),
			content: figure,
			onBefore: function(){$(".revert").show()},
			onEnd: showFigure()
		})
		return false;
	});

});

/* Sliding menu */
// $('.moreElements').click(function() {
// 	if ( $(this).next().is(":hidden") ) {
//     	$(this).next().toggle('slow');
//     	$(this).text('[-]');
// 	}else {
// 		$(this).next().toggle('slow');
// 		$(this).text('[+]');
// 	}
// });

// $(document).ready(function(){
// 	$('ul .tags').toggle();
// });

// $(document).ready(function(){
// 	$('#searchForm').keyup(function()
// 	{
		
// 		console.log('Change');
// 		var str = $(this).val;
		
// 		if (str.length==0)
// 		{ 
// 		  document.getElementById("livesearch").innerHTML="";
// 		  document.getElementById("livesearch").style.border="0px";
// 		  return;
// 		}
// 		if (window.XMLHttpRequest)
// 		{// code for IE7+, Firefox, Chrome, Opera, Safari
// 		  xmlhttp=new XMLHttpRequest();
// 		}
// 		else
// 		{// code for IE6, IE5
// 			xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
// 		}
// 		xmlhttp.onreadystatechange=function()
// 		  {
// 		  if (xmlhttp.readyState==4 && xmlhttp.status==200)
// 		  {
// 		    document.getElementById("livesearch").innerHTML=xmlhttp.responseText;
// 		    document.getElementById("livesearch").style.border="1px solid #A5ACB2";
// 		  }
// 		}
// 		xmlhttp.open("GET","livesearch.php?q="+str,true);
// 		xmlhttp.send();
// 	});
// });

// $(document).ready(function() {
// 	$("img.lazy").lazyload({ 
// 	    effect : "fadeIn"
// 	});
// });
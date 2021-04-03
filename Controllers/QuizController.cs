using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {

        static HttpClient client = new HttpClient(); 

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {

            Questions questions = null;
            client.BaseAddress = new Uri("https://opentdb.com/api.php?amount=1");

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                questions = await client.GetFromJsonAsync<Questions>(client.BaseAddress);

                var question = questions.results[0].question;
                var correstAnswer = questions.results[0].correct_answer;
                List<string> wrongAnswers = questions.results[0].incorrect_answers;


                return Ok(new {questions = question, correctAnswer = correstAnswer, wrongAnswers = wrongAnswers});
            }
            return BadRequest();

        }
    }
}
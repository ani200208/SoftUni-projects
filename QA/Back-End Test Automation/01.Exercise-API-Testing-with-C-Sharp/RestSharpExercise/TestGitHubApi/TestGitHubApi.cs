using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static int lastCreatedIssueNumber;
        private static int lastCreatedCommentId;
        

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://github.com/ani200208/SoftUni-projects/tree/main/QA", "your_username", "your_password");
            repo = "ani200208-repo"; 
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            //act 
            var issues = client.GetAllIssues(repo);
            //Assert
            Assert.That(issues, Has.Count.GreaterThan(0), "There should be more than one issue.");

            foreach(Issue issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater han 0");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater then 0");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            int issueNumber = 2;
            //act 
            var issue = client.GetIssueByNumber (repo, issueNumber);
            //Assert
                Assert.That(issue, Is.Not.Null, "The response should contain issue data.");
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.EqualTo(issueNumber), "Issue Number should be as requested.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue Title should not be empty");
            
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange
            int issueNumber = 6;
            //act 
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);
            //Assert

            Assert.That(labels.Count, Is.GreaterThan(0), "There should be labels on the issue");

            foreach(var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "Label Id should be more than 0.");
                Assert.That(label.Name, Is.Not.Null, "Label Name should not be null");

                Console.WriteLine($"label:{label.Id}-Name:{label.Name}");
            }
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            int issueNumber = 5;
            //act 
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);
            //Assert

            Assert.That(comments.Count, Is.GreaterThan(0), "There should be comments on the issue");

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "Cooment ID should be more than 0.");
                Assert.That(comment.Body, Is.Not.Empty, "Cooment Body should not be empty.");

                Console.WriteLine($"Comment:{comment.Id}-Body:{comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string title = "New Issue Title";
            string body = "Body of the new Issue";
            string expectedTitle = "Create Your own Title";
            //act 
            var issue = client.CreateIssue(repo, expectedTitle, body);
            //Assert

            Assert.Multiple(() =>
            {

                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
                Assert.That(issue.Title, Is.EqualTo(expectedTitle));
            });
                Console.WriteLine(issue.Number);
                lastCreatedIssueNumber = issue.Number;
            
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange
            int issueNumber = 5128;
            string body = "Body of the new Comment";
            
            
            //act 
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);
            //Assert

            Assert.That(comment.Body,Is.EqualTo(body));


            Console.WriteLine(comment.Id);
            lastCreatedIssueNumber = comment.Id;

        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            //Arrange
            int commentId = 1986255221;
            


            //act 
            var comment = client.GetCommentById(repo, commentId);
            //Assert

            Assert.That(comment.Body, Is.Not.Null);
            Assert.That(comment.Id,Is.EqualTo(commentId));
            Assert.That(comment.Body, Is.Not.Empty);


            
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            //Arrange
            int commentId = 1986255221;
            string newBody = "Edited comment on this issue";


            //act 
            var updatedComment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);
            //Assert

            Assert.IsNotNull(updatedComment, Is.Not.Null);
            Assert.That(updatedComment.Id, Is.EqualTo(commentId));
            Assert.That(updatedComment.Body, Is.EqualTo.(newBody));

            Console.WriteLine(comment.Body);
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            //Arrange
            int commentId =  LastCreatedIssueNumber;
            


            //act 
            var responce = client.DeleteCommentOnGitHubIssue(repo, commentId);
            //Assert
            Assert.IsTrue(result, "The comment should be successfully deleted.");
        }


    }
}


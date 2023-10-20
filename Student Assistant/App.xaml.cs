using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Student_Assistant.DbContexts;
using Student_Assistant.DTOs;
using Student_Assistant.IServices;
using Student_Assistant.Model;
using Student_Assistant.Services;
using Student_Assistant.Stores;
using Student_Assistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Student_Assistant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private  NavigationStore navigationStore;
        private const string CONNECTION_STRING= "Data Source=studentAsistan.db";
        private readonly StudentAssistantDbContextFactory _dbContextFactory;
        private readonly IQuestionCreator _questionCreator;
        private readonly IQuestionService _questionService;
        private readonly IAnswerCreator _answerCreator;
        private readonly IAnswerService _answerService;

        public App() 
        {
           _dbContextFactory = new StudentAssistantDbContextFactory(CONNECTION_STRING);
            navigationStore = new NavigationStore();
           _questionCreator = new QuestionCreator(_dbContextFactory);
           _questionService = new QuestionService(_dbContextFactory);
           _answerCreator = new AnswerCreator(_dbContextFactory);
           _answerService = new AnswerService(_dbContextFactory);
        }
        
        protected  override void OnStartup(StartupEventArgs e)
        {


            using (StudentAssistantDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
                //foreach (var item in dbContext.Questions)
                //{
                //    if (item.Id == 1 || item.Id == 2 || item.Id == 3 || item.Id == 4 || item.Id == 5 || item.Id == 6 || item.Id == 7 || item.Id == 8 || item.Id == 9 || item.Id == 10 || item.Id == 11 || item.Id == 44)
                //    {
                //        dbContext.Questions.Remove(item);
                //    }
                //}
                //dbContext.SaveChanges();

            }


            navigationStore.CurrentViewModel = new MainPageViewModel(navigationStore,_questionCreator,_questionService,_answerCreator,_answerService);
          
            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
     
      
    }
}

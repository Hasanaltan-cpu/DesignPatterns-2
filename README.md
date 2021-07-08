<h4>Design Patterns-2<h4>
<p>Total patterns will implement on BaseProject.Moreover in BaseProject,was created with carefully in terms of Inversion Of Control & Dependency Inversion Principle.</p>

[1-Strategy Design Pattern](https://github.com/Hasanaltan-cpu/DesignPatterns-2/tree/master/WebApp.StrategyDP)
<p>Main Goal Of Strategy Design Pattern : This design pattern provides us to change object's behaviour on the run time.</p>
<p>In this scenario,we have two database for using and we give chance to user can switch which database want.I use two database.One of them is SqlServer,another is MongoDb.
By using Strategy Design Pattern, u don't need to change database on compile time,u can easily change database on run time with dinamically.</p>

<h4>Requirements :<h4>

*  MongoDbAtlas
* SqlServer
* EntityFramework Core
* EntityFramework Core Identity
* EntityFramework Core SqlServer
* EntityFramework Core Tools


![Strategy Design Pattern](https://gblobscdn.gitbook.com/assets%2F-MdCvvJ7c76YPOoGbwQJ%2F-MdCvxyNdNtReLgrZiiF%2F-MdCy5uFmcL6lHU4nwPu%2FStrategyDp1.PNG?alt=media&token=ca661ff3-301e-4804-835b-f1efec54041e)

  
  [2-ChainofResponsibility Design Pattern](https://github.com/Hasanaltan-cpu/DesignPatterns-2/tree/master/WebApp.ChainOfResponsibilityDP)

  <p>Main Goal Of ChainofResponsibility Design Pattern : This design pattern provides us to bind our all process moreover seperate this process to step by step.With this way , when u want to add new part or new behaviour to your application, you can easily add a new chain in addition to that gives a chance to modify your step.</p>
  <p>In this scenario, we have 3 steps. This means our application has 3 chains:
     </p>
  
 * Excell Process
 * Zip Process
 * E-mail Process
  
  
  <h4>Requirements :<h4>
    
 * ClosedXML
 * SqlServer
 * EntityFramework Core
 * EntityFramework Core Identity
 * EntityFramework Core SqlServer
 * EntityFramework Core Tools

  
  ![ChainofResponsibility Design Pattern](https://gblobscdn.gitbook.com/assets%2F-MdCvvJ7c76YPOoGbwQJ%2F-MdGUyZYySU0MfEhGCg3%2F-MdGV5FSNPnGxwg31l-D%2FCOR.Dp.Schema.PNG?alt=media&token=73f46548-6304-4a3e-a339-2e8f5c2092ab)
  
  
  [3-Command Design Pattern](https://github.com/Hasanaltan-cpu/DesignPatterns-2/tree/master/WebApp.CommandDP)

  <p>Main Goal Of Command Design Pattern : This design pattern provides us to capsulate our all methods.When u want to modify,u can easily reach your Command invoker in addition to that it gives a chance to losely coupled classes.</p>
  <p>In this scenario, we have 3 steps. This means our application has 3 commands:
     </p>
  
 * Excell Process
 * Pdf Process
 * Excell&Pdf + Zip Process
  
  
  <h4>Requirements :<h4>
  
 * DinktoPDF
 * ClosedXML
 * SqlServer
 * EntityFramework Core
 * EntityFramework Core Identity
 * EntityFramework Core SqlServer
 * EntityFramework Core Tools

  
  ![Command Design Pattern](https://gblobscdn.gitbook.com/assets%2F-MdCvvJ7c76YPOoGbwQJ%2F-MdNPhRhsfmk9Noqf4hC%2F-MdNPjWipmivqNR0034U%2FCommandDp.PNG?alt=media&token=f60f3bbe-6764-43d1-a1c4-1b6ec909b8ae)
  
  [4-Observer Design Pattern](https://github.com/Hasanaltan-cpu/DesignPatterns-2/tree/master/WebApp.ObserverDP)

  <p>Main Goal Of Observer Design Pattern : This design pattern provides us to observe object from the other objects which is binded with it.Observer DP gives an oppurtunitty losely coupled classes in terms of high level modules to low level modules.Moreover,it provides writing codes shed light from SOLiD Principles.</p>
  <p>In this scenario, we have 3 steps. When a new user register our application:
     </p>
  
 * Log to Console;
 * Create a Discount to New User;
 * Send E-mail automatically."Wellcome www.default.com site "
  
  
  <h4>Requirements :<h4>
  
 * SqlServer
 * EntityFramework Core
 * EntityFramework Core Identity
 * EntityFramework Core SqlServer
 * EntityFramework Core Tools

    
  
  ![Observer Design Pattern](https://gblobscdn.gitbook.com/assets%2F-MdCvvJ7c76YPOoGbwQJ%2F-MdSBpww9XS3ORi3wR1C%2F-MdSD2Eq8liRzsbDxqTc%2FObserverDP.PNG?alt=media&token=3be50b2a-61d5-4bc6-b43c-8c94419d3be0)
    
    
[5-Adapter Design Pattern](https://github.com/Hasanaltan-cpu/DesignPatterns-2/tree/master/WebApp.AdapterDP)

  <p>Main Goal Of Adapter Design Pattern : Adapter Design Pattern is very common in terms of usage;because it is very usefull.Even tough application was deployed with this pattern you may change any interfaceses without touch general structure.Common example for AdapterDp is , electrical socket.When you can not use same input socket , you can add a new one which provide exchange type of your socket to suitable one.</p>
  <p>In this scenario, we have 2 steps.Our Application will watermark to our image which we save.
     </p>
  
 * Watermark to Image with Manuel code;
 * Watermark to Image with Thirdpart tool;
 * Use Adapter for this process
  
  
  <h4>Requirements :<h4>
  
 * DrawingCommon
 * A Thirdpart Image Resizer
 * EntityFramework Core
 * EntityFramework Core Identity
 * EntityFramework Core SqlServer
 * EntityFramework Core Tools

  
  ![Adepter Design Pattern](https://gblobscdn.gitbook.com/assets%2F-MdCvvJ7c76YPOoGbwQJ%2F-MdaliedXqpaP028Q787%2F-MdaltU1KCkUjdvjT43W%2FAdapterDpSchema.png?alt=media&token=19bc9cd6-7ba1-4adf-8311-f3a50fdb5096)
    
    

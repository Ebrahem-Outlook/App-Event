using Domain.Core.Base;
using System.Runtime.Serialization;

namespace Domain.Entities;

/// <summary>
/// Represinte the entity user as acalss inside Aggregate
/// </summary>
public class User : AggregateRoot
{
    /// <summary>
    /// Initialize a new instance of user class 
    /// </summary>
    /// <param name="firstName">FirstName of new user</param>
    /// <param name="lastName">LastName of new user</param>
    /// <param name="email">email of new user</param>
    /// <param name="password">password of new user</param>
    private User(string firstName, string lastName, string email, string password)
        : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    /// <summary>
    /// Required by EF Core.
    /// </summary>
    private User() { }

    /// <summary>
    /// Get and Set FirstName of the entity instance.
    /// </summary>
    public string FirstName { get; private set; } = string.Empty;

    /// <summary>
    /// Get and Set LastName of the entity instance.
    /// </summary>
    public string LastName { get; private set; } = string.Empty;

    /// <summary>
    /// Get and Set Email of the entity instance.
    /// </summary>
    public string Email { get; private set; } = string.Empty;

    /// <summary>
    /// Get and Set Password of the entity instance.
    /// </summary>
    public string Password { get; private set; } = string.Empty;

    /// <summary>
    /// Factory Method for controller the Creation Instance of the User class.
    /// </summary>
    /// <returns>New Instance of User Class.</returns>
    public static User Create(string firstName, string lastName, string email, string password)
    {
        var user = new User(firstName, lastName, email, password);

        // Event Create User 
        
        return user;
    }

    /// <summary>
    /// Method for Change the Name of User Object.
    /// </summary>
    /// <param name="firstName">The new firstName of User Object</param>
    /// <param name="lastName">The new lastName of User Object</param>
    /// <exception cref="ArgumentNullException">If any parameter is null throw Exciption.</exception>
    public void ChangeName(string firstName, string lastName)
    {
        if (firstName is null || lastName is null)
        {
            throw new ArgumentNullException();
        }

        FirstName = firstName;
        LastName = lastName;

        // Event Change Name of User Object.
    }

    /// <summary>
    /// Method for Change the email of User Object
    /// </summary>
    /// <param name="email">The new email of User Object.</param>
    /// <exception cref="ArgumentNullException">If any parameter is null throw Exciption</exception>
    public void ChangeEmail(string email)
    {
        if (email is null)
        {
            throw new ArgumentNullException();
        }

        Email = email;

        // Event Change Email of User Object.
    }

    /// <summary>
    /// Methoed of Change the password of User Object.
    /// </summary>
    /// <param name="password">The new password of User Object.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void ChangePassword(string password)
    {
        if (password is null)
        {
            throw new ArgumentNullException();
        }

        Password = password;

        // Event Change Password of User Object.
    }
}


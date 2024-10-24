namespace Logger;
public interface IEntity
{
    /*
     * We implement the GUID explicitly. We do this because, while other entities may have an ID
     * that doesn't necessarily mean it is a GUID. Students might have student IDs, employees might
     * have employee IDs, or American Citizens might have Social Security Numbers. These entities have
     * no need for a GUID and so it doesn't make sense to expose it to them. Conversely, books,
     * electronics, and records might have GUIDs. We leave it to the implementing class to determine
     * the best course of action.
     * 
     * We implement the Name property explicitly because we want to ensure that all entities have access
     * to their name.
     */
    Guid Id { get; }
    string Name { get; }
}
